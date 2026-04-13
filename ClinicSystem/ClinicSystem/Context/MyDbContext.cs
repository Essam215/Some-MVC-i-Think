using ClinicSystem.Models;
using Microsoft.EntityFrameworkCore;
using ClinicSystem.ViewModels;

namespace ClinicSystem.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(a => a.Appointments)
                .HasForeignKey(s => s.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(a => a.Appointments)
                .HasForeignKey(d => d.DoctorId);
        }
        public DbSet<ClinicSystem.ViewModels.AppointmentVM> AppointmentVM { get; set; } = default!;
    }
}
