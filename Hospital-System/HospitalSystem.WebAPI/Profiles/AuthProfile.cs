using AutoMapper;
using HospitalSystem.Common.DTO;
using HospitalSystem.Common.Models.DTOs.Auth;
using HospitalSystem.DAL.Entities.Base;

namespace Hospital_System.Profiles;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<LoginUserDTO, AuthSuccessDTO>();
        CreateMap<RegisterUserDTO, AuthSuccessDTO>();
        CreateMap<RegisterUserDTO, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
    }
}