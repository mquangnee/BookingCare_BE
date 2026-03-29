using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Queries.DoctorQuery
{
    public class GetDoctorsBySpecialtyQuery : IRequest<MethodResult<List<DoctorModel>>>
    {
        public Guid? SpecialtyId { get; set; }
    }

    public class GetdoctorsBySpecialtyQueryHandler : IRequestHandler<GetDoctorsBySpecialtyQuery, MethodResult<List<DoctorModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetdoctorsBySpecialtyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<DoctorModel>>> Handle(GetDoctorsBySpecialtyQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<DoctorModel>>();

            var services = await _unitOfWork.Services
                .QueryableAsync()
                .Where(s => s.Position != null && s.SpecialtyId != null)
                .ToListAsync(cancellationToken);
            var doctorQuery = _unitOfWork.Doctors.QueryableAsync();
            if (request.SpecialtyId.HasValue)
            {
                doctorQuery = doctorQuery.Where(x => x.SpecialtyId == request.SpecialtyId);
            }
            var doctors = await doctorQuery
                .Select(x => new DoctorModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    SpecialtyId = x.SpecialtyId,
                    DoctorCode = x.DoctorCode,
                    AvatarUrl = x.AvatarUrl,
                    FullName = x.FullName,
                    DateOfBirth = x.DateOfBirth,
                    Gender = x.Gender,
                    CitizenId = x.CitizenId,
                    ExperienceYears = x.ExperienceYears,
                    Position = x.Position,
                    SubSpecialties = x.SubSpecialties,
                    WorkingHistory = x.WorkingHistory,
                    Description = x.Description
                }).ToListAsync(cancellationToken);
            foreach (var doctor in doctors)
            {
                var service = services.FirstOrDefault(s => s.SpecialtyId == doctor.SpecialtyId && s.Position == doctor.Position);
                if (service != null)
                {
                    doctor.Price = service.Price;
                }
            }

            methodResult.Result = doctors;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
