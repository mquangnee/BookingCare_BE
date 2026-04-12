using AutoMapper;
using BookingCare.Domain.Entities;
using BookingCare.Domain.Models.EntityModels;

namespace BookingCare.Infrastructure.Maps
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<PatientProfile, PatientProfileModel>();
        }
    }
}
