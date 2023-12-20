using AutoMapper;
using HospitalSystem.Common.Models.DTOs.Doctor;
using HospitalSystem.DAL;

namespace Hospital_System.Profiles;

public class SpecialtyProfile : Profile
{
    public SpecialtyProfile()
    {
        CreateMap<SpecialtyDTO, Specialty>();
    }
}