using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Admins.Query
{
    public class GetTotalMedicinesQuery : IRequest<MethodResult<List<MedicineModel>>>
    {
    }

    public class GetTotalMedicinesQueryHandler : IRequestHandler<GetTotalMedicinesQuery, MethodResult<List<MedicineModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalMedicinesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<MedicineModel>>> Handle(GetTotalMedicinesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<MedicineModel>>();

            var medicines = await _unitOfWork.Medicines
                .QueryableAsync()
                .Select(m => new MedicineModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Unit = m.Unit,
                    Function = m.Function,
                    Status = m.Status
                })
                .ToListAsync(cancellationToken);
            methodResult.Result = medicines;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
