using ClinicSystem.Enums;

namespace ClinicSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }

        public int DoctorId { get; set;  }
        public int PatientId { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient ?Patient { get; set; }
    }
}
