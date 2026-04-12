using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Receptionists.Query
{
    public class GetWorkSessionByDateQuery : IRequest<MethodResult<List<WorkSessionModel>>>
    {
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class GetWorkSessionByDateQueryHandler : IRequestHandler<GetWorkSessionByDateQuery, MethodResult<List<WorkSessionModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWorkSessionByDateQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<WorkSessionModel>>> Handle(GetWorkSessionByDateQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var startOfDay = request.Date.Date;
            var endOfDay = startOfDay.AddDays(1);

            var query =
                from ws in _unitOfWork.WorkSessions.QueryableAsync().AsNoTracking()
                where ws.StartTime >= startOfDay && ws.StartTime < endOfDay
                from s in _unitOfWork.Services.QueryableAsync()
                    .Where(srv => srv.SpecialtyId == ws.Doctor!.SpecialtyId && srv.Position == ws.Doctor.Position)
                    .Take(1).DefaultIfEmpty()
                select new WorkSessionModel
                {
                    Id = ws.Id,
                    DoctorId = ws.DoctorId,
                    UserId = ws.Doctor!.UserId,
                    SpecialtyId = ws.Doctor.SpecialtyId,
                    DoctorCode = ws.Doctor.DoctorCode,
                    DoctorName = ws.Doctor.FullName,
                    SpecialtyName = ws.Doctor.Specialty!.Name,
                    AvatarUrl = ws.Doctor.AvatarUrl,
                    Position = ws.Doctor.Position,
                    StartTime = ws.StartTime,
                    DurationInMinutes = s != null ? s.DurationInMinutes : 0,
                    DoctorPrice = s != null ? s.Price : 0
                };
            var workSessions = await query.ToListAsync(cancellationToken);

            return new MethodResult<List<WorkSessionModel>>
            {
                Result = workSessions,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}