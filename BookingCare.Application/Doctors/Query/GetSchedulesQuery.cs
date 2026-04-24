using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingCare.Application.Doctors.Query
{
    public class GetSchedulesQuery : IRequest<MethodResult<List<WorkSessionModel>>>
    {
        public DateTime StartDate { get; set; }
    }

    public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, MethodResult<List<WorkSessionModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetSchedulesQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MethodResult<List<WorkSessionModel>>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<WorkSessionModel>>();

            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.Unauthorized));
                return methodResult;
            }

            var doctor = await _unitOfWork.Doctors
                .QueryableAsync()
                .Where(d => d.UserId == userId)
                .Select(d => new 
                { 
                    d.Id,
                    d.DoctorCode
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (doctor == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(doctor));
                return methodResult;
            }

            var startDate = request.StartDate.Date;
            var endLimit = startDate.AddDays(8);

            var workSessionModel = await _unitOfWork.WorkSessions
                .QueryableAsync()
                .Where(ws => ws.DoctorId == doctor.Id && ws.StartTime >= startDate && ws.EndTime < endLimit)
                .Select(ws => new WorkSessionModel
                {
                    Id = ws.Id,
                    UserId = userId,
                    DoctorId = doctor.Id,
                    DoctorCode = doctor.DoctorCode,
                    Date = ws.StartTime.Date,
                    StartTime = ws.StartTime,
                    EndTime = ws.EndTime
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = workSessionModel;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
