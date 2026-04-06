using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetTotalDoctorsQuery : IRequest<MethodResult<DashboardMetricModel<DoctorModel>>>
    {
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

            var today = DateTime.Now;
            var totalDoctors = await _unitOfWork.Doctors
                .QueryableAsync()
                .Include(d => d.User)
                .Where(d => d.User != null && d.User.LockoutEnd != null && d.User.LockoutEnd < today)
                .Select(d => new DoctorModel
                {
                    Id = d.Id,
                    UserId = d.UserId,
                    SpecialtyId = d.SpecialtyId,
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
                    SubSpecialties = d.SubSpecialties,
                    WorkingHistory = d.WorkingHistory,
                    Description = d.Description
                })
                .ToListAsync(cancellationToken);

            var dashboardModel = new DashboardMetricModel<DoctorModel>
            {
                Total = totalDoctors.Count,
                Data = totalDoctors
            };
            methodResult.Result = dashboardModel;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
