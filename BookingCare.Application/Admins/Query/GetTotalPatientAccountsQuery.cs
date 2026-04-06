using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetTotalPatientAccountsQuery : IRequest<MethodResult<DashboardMetricModel<PatientModel>>>
    {
    }

    public class GetTotalPatientAccountsQueryHandler : IRequestHandler<GetTotalPatientAccountsQuery, MethodResult<DashboardMetricModel<PatientModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalPatientAccountsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<DashboardMetricModel<PatientModel>>> Handle(GetTotalPatientAccountsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<DashboardMetricModel<PatientModel>>();

            var today = DateTime.Now;
            var totalPatientAccounts = await _unitOfWork.PatientProfiles
                .QueryableAsync()
                .Include(pp => pp.Patient)
                    .ThenInclude(pp => pp.User)
                .Where(pp => pp.Patient!.User != null && pp.Patient.User.LockoutEnd != null && pp.Patient.User.LockoutEnd < today && pp.Relationship == EnumRelationship.MySelf)
                .Select(pp => new PatientModel
                {
                    Id = pp.PatientId,
                    UserId = pp.Patient!.UserId,
                    PatientCode = pp.Patient.PatientCode,
                    Email = pp.Patient!.User!.Email,
                    PhoneNumber = pp.Patient.User.PhoneNumber,
                    FullName = pp.FullName,
                    DateOfBirth = pp.DateOfBirth,
                    Gender = pp.Gender,
                    CitizenId = pp.CitizenId,
                    BloodType = pp.BloodType,
                    MedicalHistory = pp.MedicalHistory
                })
                .ToListAsync(cancellationToken);

            var dashboardModel = new DashboardMetricModel<PatientModel>
            {
                Total = totalPatientAccounts.Count,
                Data = totalPatientAccounts
            };
            methodResult.Result = dashboardModel;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
