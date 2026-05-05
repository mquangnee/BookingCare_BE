using BookingCare.Domain.IRepository;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Command
{
    public class ChangeStatusServiceCommand : IRequest<MethodResult<bool>>
    {
        public Guid ServiceId { get; set; }
    }

    public class ChangeStatusServiceCommandHandler : IRequestHandler<ChangeStatusServiceCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeStatusServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<bool>> Handle(ChangeStatusServiceCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var service = await _unitOfWork.Services.GetByIdAsync(request.ServiceId);
            if (service == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.ServiceId), request.ServiceId.ToString());
                return methodResult;
            }

            if (service.IsActive)
            {
                var hasDoctors = await _unitOfWork.Doctors.QueryableAsync().AnyAsync(d => d.ServiceId == request.ServiceId, cancellationToken);
                if (hasDoctors)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumDashboardErrorCode.ServiceHasDoctorsCannotDeactivate));
                    return methodResult;
                }
            }

            service.IsActive = !service.IsActive;

            _unitOfWork.Services.Update(service);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
