using BookingCare.Domain.IRepository;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace BookingCare.Domain.Models.CommandModels
{
    public class UpdateServiceCommand : UpdateServiceCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<bool>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var service = await _unitOfWork.Services.GetByIdAsync(request.Id);
            if (service == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.Id), request.Id.ToString());
                return methodResult;
            }

            if (request.SpecialtyId.HasValue)
            {
                var specialty = await _unitOfWork.Specialties.GetByIdAsync(request.SpecialtyId.Value);
                if (specialty == null)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.SpecialtyId), request.SpecialtyId.ToString());
                    return methodResult;
                }
                var doctor = await _unitOfWork.Doctors
                    .QueryableAsync()
                    .AnyAsync(d => d.SpecialtyId == request.SpecialtyId.Value, cancellationToken);
                if (doctor)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumDashboardErrorCode.ServiceHasDoctorsCannotDeactivate));
                    return methodResult;
                }
                service.SpecialtyId = request.SpecialtyId;
            }

            if (request.DurationInMinutes <= 0 || request.Price <= 0)
            {
                methodResult.AddErrorBadRequest(nameof(EnumDashboardErrorCode.DurationInMinutesOrPriceInvalid));
                return methodResult;
            }

            if (!string.IsNullOrWhiteSpace(request.Name) && request.Name != service.Name)
            {
                var isExistName = await _unitOfWork.Services.QueryableAsync()
                    .AnyAsync(s => s.Name == request.Name && s.Id != request.Id, cancellationToken);
                if (isExistName)
                {
                    methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.Name), request.Name);
                    return methodResult;
                }
                service.Name = request.Name;
            }

            service.Price = request.Price;
            service.Description = request.Description;
            service.DurationInMinutes = request.DurationInMinutes;

            _unitOfWork.Services.Update(service);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = true;
            methodResult.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
