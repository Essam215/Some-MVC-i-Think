using ClinicSystem.Models;

namespace ClinicSystem.Repo.Interfaces
{
    public interface IAppointmentRepo
    {
        Task AddAsync(Appointment? appointment);
        void Delete(Appointment appointment);
        void Update(Appointment appointment);
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task SaveAsync();
    }
}
