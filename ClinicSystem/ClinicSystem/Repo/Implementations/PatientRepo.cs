using ClinicSystem.Context;
using ClinicSystem.Models;
using ClinicSystem.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Repo.Implementations
{
    public class PatientRepo : IPatientRepo
    {
        private readonly MyDbContext _patientRepo;

        public PatientRepo(MyDbContext patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task AddAsync(Patient patient)
        {
            await _patientRepo.Patients.AddAsync(patient);
        }

        public void Delete(Patient patient)
        {
             _patientRepo.Remove(patient);
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _patientRepo.Patients.ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _patientRepo.Patients
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveAsync()
        {
            await _patientRepo.SaveChangesAsync();
        }

        public void UpdateAsync(Patient patient)
        {
            _patientRepo.Update(patient);
        }
    }
}
