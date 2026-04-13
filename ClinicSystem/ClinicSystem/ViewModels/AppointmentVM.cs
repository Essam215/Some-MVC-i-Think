using ClinicSystem.Models;

namespace ClinicSystem.ViewModels
{
    public class AppointmentVM
    {
        public int Id { get; set; }
        public Appointment ?Appointment { get; set; }

        public List<Doctor> ?Doctors { get; set; }
        public List<Patient> ?Patients { get; set; }
    }
}
