using ClinicSystem.Models;

namespace ClinicSystem.Repo.Interfaces
{
    public interface IDoctorRepo
    {
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task SaveAsync();
        Task AddAsync(Doctor doctor);
        void Delete(Doctor doctor);
        void UpdateAsync(Doctor doctor);
    }
}
