using ClinicSystem.Models;
using ClinicSystem.Repo.Interfaces;
using ClinicSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepo _Db;
        private readonly IDoctorRepo _doctorRepo;
        private readonly IPatientRepo _patientRepo;

        public AppointmentController(
            IAppointmentRepo db,
            IDoctorRepo doctorRepo,
            IPatientRepo patientRepo)
        {
            _Db = db;
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _Db.GetAllAsync();
            return View(appointments);
        }

        public async Task<IActionResult> Create()
        {
            var vm = new AppointmentVM
            {
                Doctors = await _doctorRepo.GetAllAsync(),
                Patients = await _patientRepo.GetAllAsync(),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Doctors = await _doctorRepo.GetAllAsync();
                vm.Patients = await _patientRepo.GetAllAsync();

                return View(vm);
            }

            await _Db.AddAsync(vm.Appointment);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _Db.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            var vm = new AppointmentVM
            {
                Appointment = appointment,
                Doctors = await _doctorRepo.GetAllAsync(),
                Patients = await _patientRepo.GetAllAsync(),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppointmentVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Doctors = await _doctorRepo.GetAllAsync();
                vm.Patients = await _patientRepo.GetAllAsync();

                return View(vm);
            }

            _Db.Update(vm.Appointment);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _Db.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _Db.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            _Db.Delete(appointment);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}