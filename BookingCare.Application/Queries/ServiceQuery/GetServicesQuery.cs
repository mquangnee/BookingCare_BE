using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingCare.Application.Queries.ServiceQuery
{
    public class GetServicesQuery : IRequest<MethodResult<List<ServiceModel>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Keyword { get; set; }
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

            var services = await _unitOfWork.Services.GetAllAsync();
            var query = services.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Keyword))
            {
                var keyword = request.Keyword.Trim();
                query = query.Where(s => 
                    (s.Name != null && s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (s.ServiceCode != null && s.ServiceCode.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
            }
            methodResult.Result = query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
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
                .ToList();
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}