using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;

namespace BookingCare.Application.Queries.SpecialtyQuery
{
    public class GetSpecialtiesQuery : IRequest<MethodResult<List<SpecialtyModel>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Keyword { get; set; }
    }

    public class GetSpecialtiesQueryHandler : IRequestHandler<GetSpecialtiesQuery, MethodResult<List<SpecialtyModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSpecialtiesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<SpecialtyModel>>> Handle(GetSpecialtiesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<SpecialtyModel>>();

            var specialties = await _unitOfWork.Specialties.GetAllAsync();
            var query = specialties.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Keyword))
            {
                var keyword = request.Keyword.Trim();
                query = query.Where(x =>
                    (x.Name != null && x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (x.SpecialtyCode != null && x.SpecialtyCode.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
            }
            methodResult.Result = query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new SpecialtyModel
                {
                    Id = x.Id,
                    SpecialtyCode = x.SpecialtyCode,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description
                })
                .ToList();
            return methodResult;
        }
    }
}
