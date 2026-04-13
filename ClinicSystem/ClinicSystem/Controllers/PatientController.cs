using ClinicSystem.Models;
using ClinicSystem.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepo _Db;

        public PatientController(IPatientRepo db)
        {
            _Db = db;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _Db.GetAllAsync();
            return View(patients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (!ModelState.IsValid)
                return View(patient);

            await _Db.AddAsync(patient);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _Db.GetByIdAsync(id);

            if (patient == null)
                return NotFound();

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Patient patient)
        {
            if (!ModelState.IsValid)
                return View(patient);

            _Db.UpdateAsync(patient);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _Db.GetByIdAsync(id);

            if (patient == null)
                return NotFound();

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _Db.GetByIdAsync(id);

            if (patient == null)
                return NotFound();

            _Db.Delete(patient);
            await _Db.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}