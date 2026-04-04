using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Queries.ProfileQuery
{
    public class GetUserProfilesForBookingQuery : IRequest<MethodResult<List<UserProfileModel>>>
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }   
    }

    public class GetUserProfilesForBookingQueryHandler : IRequestHandler<GetUserProfilesForBookingQuery, MethodResult<List<UserProfileModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserProfilesForBookingQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<List<UserProfileModel>>> Handle(GetUserProfilesForBookingQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<UserProfileModel>>();

            // 1. Lấy UserId từ Token
            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }

            var patient = await _unitOfWork.Patients.QueryableAsync().FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);
            if (patient == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(patient));
                return methodResult;
            }

            // 2. Lấy hồ sơ của chính mình
            var myProfiles = await _unitOfWork.PatientProfiles.QueryableAsync()
                .Where(p => p.PatientId == patient.Id)
                .Select(p => new UserProfileModel
                {
                    Id = p.Id,
                    PatientCode = patient.PatientCode,
                    ProfileCode = p.ProfileCode,
                    FullName = p.FullName,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    PhoneNumber = p.PhoneNumber,
                    Relationship = p.Relationship,
                    BloodType = p.BloodType,
                    MedicalHistory = p.MedicalHistory,
                    IsShared = false
                })
                .ToListAsync(cancellationToken);

            // 3. Lấy hồ sơ được người khác chia sẻ
            var sharedProfiles = await (from ps in _unitOfWork.ProfileShares.QueryableAsync()
                                        join p in _unitOfWork.PatientProfiles.QueryableAsync() on ps.PatientProfileId equals p.Id
                                        join pt in _unitOfWork.Patients.QueryableAsync() on p.PatientId equals pt.Id
                                        where ps.SharedToUserId == userId 
                                           && ps.ShareStatus == Shared.Enum.EnumShareStatus.Accepted 
                                           && (ps.SharePermission == Shared.Enum.EnumSharePermission.BookAppointment || ps.SharePermission == Shared.Enum.EnumSharePermission.FullAccess)
                                        select new UserProfileModel
                                        {
                                            Id = p.Id,
                                            PatientCode = pt.PatientCode,
                                            ProfileCode = p.ProfileCode,
                                            FullName = p.FullName,
                                            DateOfBirth = p.DateOfBirth,
                                            Gender = p.Gender,
                                            PhoneNumber = p.PhoneNumber,
                                            Relationship = p.Relationship,
                                            BloodType = p.BloodType,
                                            MedicalHistory = p.MedicalHistory,
                                            IsShared = true,
                                            // Chú ý: Đảm bảo UserProfileModel có thuộc tính SharePermission nếu muốn gán
                                        }).ToListAsync(cancellationToken);

            // 4. Gộp danh sách và loại bỏ trùng lặp
            var allProfiles = myProfiles.Concat(sharedProfiles)
                                        .GroupBy(p => p.Id)
                                        .Select(g => g.First())
                                        .ToList();

            var profileIds = allProfiles.Select(p => p.Id).ToList();

            // 5. TÌM CÁC HỒ SƠ ĐANG BẬN TRONG KHUNG GIỜ NÀY (THUẬT TOÁN OVERLAP)
            var bookedProfileIds = await _unitOfWork.Appointments.QueryableAsync()
                .Where(a => a.Date.Date == request.Date.Date
                         && a.Status != Shared.Enum.EnumAppointmentStatus.Canceled
                         && profileIds.Contains(a.PatientProfileId)
                         // Thuật toán kiểm tra trùng lịch (Overlap): StartA < EndB AND EndA > StartB
                         && a.StartTime < request.EndTime 
                         && a.EndTime > request.StartTime)
                .Select(a => a.PatientProfileId)
                .Distinct() // Tránh lấy trùng ID nếu 1 người có nhiều lịch lỗi
                .ToListAsync(cancellationToken);


            // --- Lựa chọn 2: Nếu bạn vẫn muốn ẨN HẲN hồ sơ bận đi (Xóa bỏ comment dòng dưới nếu dùng) ---
            var availableProfiles = allProfiles.Where(p => !bookedProfileIds.Contains(p.Id)).ToList();
            methodResult.Result = availableProfiles;

            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}