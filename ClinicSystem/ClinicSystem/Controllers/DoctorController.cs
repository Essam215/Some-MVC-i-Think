using ClinicSystem.Models;
using ClinicSystem.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepo _Db;
        public DoctorController(IDoctorRepo db)
        {
            _Db = db;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _Db.GetAllAsync();
            return View(doctors);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!ModelState.IsValid)        
                return View(doctor);
            
            await _Db.AddAsync(doctor);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _Db.GetByIdAsync(id);

            if (doctor == null) return NotFound();

            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (!ModelState.IsValid) return View(doctor);

             _Db.UpdateAsync(doctor);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _Db.GetByIdAsync(id);

            if (doctor == null) return NotFound();

            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _Db.GetByIdAsync(id);

            if (doctor == null) return NotFound();

            _Db.Delete(doctor);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
