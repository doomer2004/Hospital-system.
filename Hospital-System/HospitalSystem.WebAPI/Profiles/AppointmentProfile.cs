using AutoMapper;
using HospitalSystem.Common.Models.DTOs.Appointment;
using HospitalSystem.DAL.Entities;

namespace Hospital_System.Profiles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<AppointmentDTO, Appointment>();
    }
}