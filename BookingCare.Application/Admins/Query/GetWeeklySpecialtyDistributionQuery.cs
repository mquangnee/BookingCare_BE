using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetWeeklySpecialtyDistributionQuery : IRequest<MethodResult<List<SpecialtyDistributionModel>>>
    {
    }

    public class GetWeeklySpecialtyDistributionQueryHandler : IRequestHandler<GetWeeklySpecialtyDistributionQuery, MethodResult<List<SpecialtyDistributionModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWeeklySpecialtyDistributionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<SpecialtyDistributionModel>>> Handle(GetWeeklySpecialtyDistributionQuery request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<List<SpecialtyDistributionModel>>();

            var today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            var startOfWeek = today.AddDays(-1 * diff);
            var endOfWeek = startOfWeek.AddDays(7);

            var distribution = await _unitOfWork.Appointments
                .QueryableAsync()
                .Include(a => a.WorkSession)
                    .ThenInclude(ws => ws.Doctor)
                        .ThenInclude(d => d.Specialty)
                .Where(a => a.Date >= startOfWeek && a.Date < endOfWeek)
                .GroupBy(a => a.WorkSession.Doctor.Specialty.Name)
                .Select(g => new SpecialtyDistributionModel
                {
                    Label = g.Key,
                    Value = g.Count()
                })
                .OrderByDescending(x => x.Value)
                .ToListAsync(cancellationToken);

            methodResult.Result = distribution;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}