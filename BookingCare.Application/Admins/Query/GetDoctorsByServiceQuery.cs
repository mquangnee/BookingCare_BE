using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetDoctorsByServiceQuery : IRequest<MethodResult<ServiceModel>>
    {
        public Guid ServiceId { get; set; }
    }

    public class GetDoctorsByServiceQueryHandler : IRequestHandler<GetDoctorsByServiceQuery, MethodResult<ServiceModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDoctorsByServiceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<ServiceModel>> Handle(GetDoctorsByServiceQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<ServiceModel>();

            var service = await _unitOfWork.Services.GetByIdAsync(request.ServiceId);
            if (service == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.ServiceId), request.ServiceId);
                return methodResult;
            }

            var doctors = await _unitOfWork.Doctors
                .QueryableAsync()
                .Include(d => d.User)
                .Where(d => d.ServiceId == request.ServiceId && d.User!.LockoutEnd == null)
                .Select(d => new DoctorModel
                {
                    Id = d.Id,
                    UserId = d.UserId,
                    ServiceId = d.ServiceId,
                    SpecialtyId = d.SpecialtyId,
                    DoctorCode = d.DoctorCode,
                    Email = d.User!.Email,
                    PhoneNumber = d.User!.PhoneNumber,
                    AvatarUrl = d.AvatarUrl,
                    FullName = d.FullName,
                    DateOfBirth = d.DateOfBirth,
                    Gender = d.Gender,
                    CitizenId = d.CitizenId,
                    ExperienceYears = d.ExperienceYears,
                    Position = d.Position,
                    WorkingHistory = d.WorkingHistory,
                    Description = d.Description
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = new ServiceModel
            {
                Id = service.Id,
                SpecialtyId = service.SpecialtyId,
                ServiceCode = service.ServiceCode,
                Name = service.Name,
                Price = service.Price,
                Description = service.Description,
                DurationInMinutes = service.DurationInMinutes,
                IsActive = service.IsActive,
                Doctors = doctors
            };

            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
