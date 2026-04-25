using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetServicesBySpecialtyQuery : IRequest<MethodResult<List<ServiceModel>>>
    {
        public Guid SpecialtyId { get; set; }
    }

    public class GetServicesBySpecialtyQueryHandler : IRequestHandler<GetServicesBySpecialtyQuery, MethodResult<List<ServiceModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetServicesBySpecialtyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<MethodResult<List<ServiceModel>>> Handle(GetServicesBySpecialtyQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<ServiceModel>>();

            var services = await _unitOfWork.Services
                .QueryableAsync()
                .Where(s => s.SpecialtyId == request.SpecialtyId && s.IsActive == true)
                .ToListAsync(cancellationToken);

            var serviceModels = services.Select(s => new ServiceModel
            {
                Id = s.Id,
                ServiceCode = s.ServiceCode,
                Name = s.Name,
                Price = s.Price,
                Description = s.Description,
                DurationInMinutes = s.DurationInMinutes,
                IsActive = s.IsActive
            }).ToList();

            methodResult.Result = serviceModels;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
