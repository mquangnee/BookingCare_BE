using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.EntityModels;
using BookingCare.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingCare.Application.Receptionists.Query
{
    public class SearchPatientProfileQuery : IRequest<MethodResult<List<PatientProfileModel>>>
    {
        public string? Keyword { get; set; }
    }

    public class SearchPatientProfileQueryHandler : IRequestHandler<SearchPatientProfileQuery, MethodResult<List<PatientProfileModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchPatientProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MethodResult<List<PatientProfileModel>>> Handle(SearchPatientProfileQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<List<PatientProfileModel>>();

            if (string.IsNullOrWhiteSpace(request.Keyword))
            {
                return methodResult;
            }

            var keyword = request.Keyword.Trim();

            var patientProfiles = await _unitOfWork.PatientProfiles.QueryableAsync()
                .AsNoTracking()
                .Where(p => p.FullName!.Contains(keyword) ||
                            p.PhoneNumber!.Contains(keyword) ||
                            p.CitizenId!.Contains(keyword))
                .Select(p => new PatientProfileModel
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    CitizenId = p.CitizenId,
                    PhoneNumber = p.PhoneNumber
                })
                .Take(20)   
                .ToListAsync(cancellationToken);

            return new MethodResult<List<PatientProfileModel>>
            {
                Result = patientProfiles,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}