using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.DAL.Context;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Doctor> Doctors { get; set; } = null!;
    public virtual DbSet<DoctorsSpecialty> DoctorsSpecialty { get; set; } = null!;
    public virtual DbSet<Specialty> Specialty { get; set; } = null!;
    public virtual DbSet<Patient> Patients { get; set; } = null!;
    public virtual DbSet<DoctorTimeSlots> DoctorTimeSlots { get; set; } = null!;
    public virtual DbSet<Appointment> Appointments { get; set; } = null!;
}