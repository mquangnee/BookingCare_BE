using BookingCare.Application.Services;
using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Command
{
    public class CreateServiceCommand : CreateServiceCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneratorCodeService _generatorCodeService;

        public CreateServiceCommandHandler(IUnitOfWork unitOfWork, IGeneratorCodeService generatorCodeService)
        {
            _unitOfWork = unitOfWork;
            _generatorCodeService = generatorCodeService;
        }

        public async Task<MethodResult<bool>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            if (request.DurationInMinutes <= 0 || request.Price <= 0)
            {
                methodResult.AddErrorBadRequest(nameof(EnumDashboardErrorCode.DurationInMinutesOrPriceInvalid));
                return methodResult;
            }

            var serviceExists = await _unitOfWork.Services.QueryableAsync().AnyAsync(s => s.Name == request.Name, cancellationToken);
            if (serviceExists)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataAlreadyExist), nameof(request.Name), request.Name);
                return methodResult;
            }

            var specialty = await _unitOfWork.Specialties.GetByIdAsync(request.SpecialtyId ?? Guid.Empty);
            if (specialty == null)
            {
                methodResult.AddErrorBadRequest(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.SpecialtyId), request.SpecialtyId.ToString());
                return methodResult;
            }

            var newService = new Service
            {
                Id = Guid.NewGuid(),
                SpecialtyId = request.SpecialtyId,
                ServiceCode = await _generatorCodeService.GenerateServiceCodeAsync(),
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                DurationInMinutes = request.DurationInMinutes,
                IsActive = true
            };

            await _unitOfWork.Services.AddAsync(newService);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status201Created;
            return methodResult;
        }
    }
}
