using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetServicesQuery : IRequest<MethodResult<List<ServiceModel>>>
    {
    }

    public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, MethodResult<List<ServiceModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetServicesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<ServiceModel>>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<ServiceModel>>();

            var services = await _unitOfWork.Services
                .QueryableAsync()
                .Where(s => s.IsActive == true && s.Position == null)
                .Select(s => new ServiceModel
                {
                    Id = s.Id,
                    SpecialtyId = s.SpecialtyId,
                    ServiceCode = s.ServiceCode,
                    Name = s.Name,
                    Price = s.Price,
                    Description = s.Description,
                    DurationInMinutes = s.DurationInMinutes,
                    IsActive = s.IsActive
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = services;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
