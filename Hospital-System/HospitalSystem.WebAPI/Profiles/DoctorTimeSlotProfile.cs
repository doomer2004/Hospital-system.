using AutoMapper;
using HospitalSystem.Common.Models.DTOs.Doctor;
using HospitalSystem.DAL.Entities;

namespace Hospital_System.Profiles;

public class DoctorTimeSlotProfile : Profile
{
    public DoctorTimeSlotProfile()
    {
        CreateMap<DoctorTimeSlotsDTO, DoctorTimeSlot>();
    }
}