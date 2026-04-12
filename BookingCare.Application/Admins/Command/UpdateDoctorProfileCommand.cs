using BookingCare.Domain.Entities;
using BookingCare.Domain.IRepository;
using BookingCare.Domain.Models.CommandModels;
using BookingCare.Shared.Common;
using BookingCare.Shared.Enum.ErrorCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BookingCare.Application.Admins.Command
{
    public class UpdateDoctorProfileCommand : UpdateDoctorProfileCommandModel, IRequest<MethodResult<bool>>
    {
    }

    public class UpdateDoctorProfileCommandHandler : IRequestHandler<UpdateDoctorProfileCommand, MethodResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public UpdateDoctorProfileCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<MethodResult<bool>> Handle(UpdateDoctorProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var methodResult = new MethodResult<bool>();

            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.DoctorId);
            if (doctor == null)
            {
                methodResult.AddError(nameof(EnumSystemErrorCode.DataNotExist), nameof(request.DoctorId), request.DoctorId);
                return methodResult;
            }
            var user = await _userManager.FindByIdAsync(doctor.UserId.ToString());
            if (user == null)
            {
                methodResult.AddError(nameof(EnumSystemErrorCode.DataNotExist), nameof(doctor.UserId), doctor.UserId);
                return methodResult;
            }
            doctor.SpecialtyId = request.SpecialtyId;
            doctor.Position = request.Position;
            doctor.ExperienceYears = request.ExperienceYears;
            doctor.Description = request.Description;
            doctor.WorkingHistory = request.WorkingHistory;
            _unitOfWork.Doctors.Update(doctor);

            user.PhoneNumber = request.PhoneNumber;
            user.UpdatedDate = DateTime.Now;
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var res = await _userManager.UpdateAsync(user);
            if (res.Succeeded == false)
            {
                methodResult.AddError(nameof(EnumDashboardErrorCode.UpdateInfoFailed));
                return methodResult;
            }

            methodResult.Result = true;
            methodResult.StatusCode = StatusCodes.Status200OK;
            return methodResult;
        }
    }
}
