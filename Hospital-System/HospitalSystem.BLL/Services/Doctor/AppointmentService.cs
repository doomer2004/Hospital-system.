using AutoMapper;
using HospitalSystem.Common.Models.DTOs.Appointment;
using HospitalSystem.DAL;
using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.BLL.Services.Doctor;

public class AppointmentService
{
    private readonly IRepository<DAL.Entities.Appointment> _repositoryAppointment;
    private readonly IRepository<DAL.Doctor> _repositoryDoctor;
    private readonly IRepository<Patient> _repositoryPatient;
    private readonly IMapper _mapper;

    public AppointmentService(IMapper mapper, IRepository<DAL.Entities.Appointment> repositoryAppointment, IRepository<> repositoryDoctor, IRepository<Patient> repositoryPatient)
    {
        _mapper = mapper;
        _repositoryAppointment = repositoryAppointment;
        _repositoryDoctor = repositoryDoctor;
        _repositoryPatient = repositoryPatient;
    }

    public async Task<bool> CreateAppointmentAsync(AppointmentDTO appointment, Guid doctorId, Guid patientId)
    {
         
    }
    

}