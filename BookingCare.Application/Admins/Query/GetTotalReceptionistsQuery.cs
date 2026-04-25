using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BookingCare.Shared.Enum;

namespace BookingCare.Application.Admins.Query
{
    public class GetTotalReceptionistsQuery : IRequest<MethodResult<DashboardMetricModel<ReceptionistModel>>>
    {
    }

    public class GetTotalReceptionistsQueryHandler : IRequestHandler<GetTotalReceptionistsQuery, MethodResult<DashboardMetricModel<ReceptionistModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalReceptionistsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<DashboardMetricModel<ReceptionistModel>>> Handle(GetTotalReceptionistsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<DashboardMetricModel<ReceptionistModel>>();

            var query = _unitOfWork.Receptionists
                .QueryableAsync()
                .Include(r => r.User);

            var totalReceptionists = await query
                .Select(r => new ReceptionistModel
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    ReceptionistCode = r.ReceptionistCode,
                    Email = r.User!.Email,
                    PhoneNumber = r.User.PhoneNumber,
                    AvatarUrl = r.AvatarUrl,
                    FullName = r.FullName,
                    DateOfBirth = r.DateOfBirth,
                    Gender = r.Gender,
                    CitizenId = r.CitizenId,
                    Status = r.User.LockoutEnd == null ? EnumStatus.Active : EnumStatus.Inactive,
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = new DashboardMetricModel<ReceptionistModel>
            {
                Total = totalReceptionists.Count,
                Data = totalReceptionists
            };

            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}