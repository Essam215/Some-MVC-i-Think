using ClinicSystem.Models;

namespace ClinicSystem.Repo.Interfaces
{
    public interface IPatientRepo
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task SaveAsync();
        Task AddAsync(Patient patient);
        void Delete(Patient patient);
        void UpdateAsync(Patient patient);
    }
}
