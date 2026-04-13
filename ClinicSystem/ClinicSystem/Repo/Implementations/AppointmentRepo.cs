using ClinicSystem.Context;
using ClinicSystem.Models;
using ClinicSystem.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

public class AppointmentRepo : IAppointmentRepo
{
    private readonly MyDbContext _context;

    public AppointmentRepo(MyDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Appointment? appointment)
    {
        await _context.Appointments.AddAsync(appointment);
    }

    public void Delete(Appointment appointment)
    {
        _context.Appointments.Remove(appointment);
    }

    public void Update(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
    }

    public async Task<List<Appointment>> GetAllAsync()
    {
        return await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int id)
    {
        return await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}