using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetTotalServicesQuery : IRequest<MethodResult<DashboardMetricModel<ServiceModel>>>
    {
    }

    public class GetTotalServicesQueryHandler : IRequestHandler<GetTotalServicesQuery, MethodResult<DashboardMetricModel<ServiceModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalServicesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<DashboardMetricModel<ServiceModel>>> Handle(GetTotalServicesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<DashboardMetricModel<ServiceModel>>();

            var totalServices = await _unitOfWork.Services
                .QueryableAsync()
                .Where(s => s.IsActive == true)
                .Select(s => new ServiceModel
                {
                    Id = s.Id,
                    ServiceCode = s.ServiceCode,
                    Name = s.Name,
                    Price = s.Price,
                    Description = s.Description,
                    DurationInMinutes = s.DurationInMinutes,
                    IsActive = s.IsActive
                })
                .ToListAsync(cancellationToken);
            var dashboardModel = new DashboardMetricModel<ServiceModel>
            {
                Data = totalServices,
                Total = totalServices.Count
            };
            methodResult.Result = dashboardModel;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
