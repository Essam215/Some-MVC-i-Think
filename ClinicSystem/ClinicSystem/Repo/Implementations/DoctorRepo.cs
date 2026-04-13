using ClinicSystem.Context;
using ClinicSystem.Models;
using ClinicSystem.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Repo.Implementations
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly MyDbContext _doctorRepo;
        public DoctorRepo(MyDbContext doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _doctorRepo.Doctors.AddAsync(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _doctorRepo.Remove(doctor);
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _doctorRepo.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
           return await _doctorRepo.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task SaveAsync()
        {
            await _doctorRepo.SaveChangesAsync();
        }

        public void UpdateAsync(Doctor doctor)
        {
            _doctorRepo.Update(doctor);
        }
    }
}
