using AutoMapper;
using HospitalSystem.Common.Models.DTOs.Doctor;
using HospitalSystem.DAL;
using HospitalSystem.DAL.Entities;

namespace Hospital_System.Profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<CreateDoctorDTO, Doctor>();
        CreateMap<DoctorDTO, Doctor>()
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime));
    }
}