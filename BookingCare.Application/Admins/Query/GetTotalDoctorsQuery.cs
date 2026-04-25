using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BookingCare.Shared.Enum;

namespace BookingCare.Application.Admins.Query
{
    public class GetTotalDoctorsQuery : IRequest<MethodResult<DashboardMetricModel<DoctorModel>>>
    {
        public Guid SpecialtyId { get; set; }
        public bool IsActived { get; set; }
    }

    public class GetTotalDoctorsQueryHandler : IRequestHandler<GetTotalDoctorsQuery, MethodResult<DashboardMetricModel<DoctorModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalDoctorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<DashboardMetricModel<DoctorModel>>> Handle(GetTotalDoctorsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<DashboardMetricModel<DoctorModel>>();

            var query = _unitOfWork.Doctors
                .QueryableAsync()
                .Include(d => d.User)
                .Include(d => d.Specialty);

            var totalDoctors = await query
                .Select(d => new DoctorModel
                {
                    Id = d.Id,
                    UserId = d.UserId,
                    ServiceId = d.ServiceId,
                    SpecialtyId = d.SpecialtyId,
                    SpecialtyName = d.Specialty != null ? d.Specialty.Name : "Chưa xác định",
                    DoctorCode = d.DoctorCode,
                    Email = d.User!.Email,
                    PhoneNumber = d.User.PhoneNumber,
                    AvatarUrl = d.AvatarUrl,
                    FullName = d.FullName,
                    DateOfBirth = d.DateOfBirth,
                    Gender = d.Gender,
                    CitizenId = d.CitizenId,
                    ExperienceYears = d.ExperienceYears,
                    Position = d.Position,
                    WorkingHistory = d.WorkingHistory,
                    Description = d.Description,
                    Status = d.User.LockoutEnd == null ? EnumStatus.Active : EnumStatus.Inactive,
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = new DashboardMetricModel<DoctorModel>
            {
                Total = totalDoctors.Count,
                Data = totalDoctors
            };

            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
