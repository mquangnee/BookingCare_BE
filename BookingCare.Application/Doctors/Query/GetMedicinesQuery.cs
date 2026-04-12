using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Doctors.Query
{
    public class GetMedicinesQuery : IRequest<MethodResult<List<MedicineModel>>>
    {
    }

    public class GetMedicinesQueryHandler : IRequestHandler<GetMedicinesQuery, MethodResult<List<MedicineModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMedicinesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<MedicineModel>>> Handle(GetMedicinesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<MedicineModel>>();

            var medicines = await _unitOfWork.Medicines
                .QueryableAsync()
                .Where(m => m.Status == EnumStatus.Active)
                .Select(m => new MedicineModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Unit = m.Unit,
                    Function = m.Function
                })
                .ToListAsync(cancellationToken);

            methodResult.Result = medicines;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
