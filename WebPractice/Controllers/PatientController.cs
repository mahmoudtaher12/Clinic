using Microsoft.AspNetCore.Mvc;
using WebPractice.Models.Entites;
using WebPractice.Repo.repo;

namespace WebPractice.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatient repo;
        public PatientController(IPatient repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> GetAll()
        {
            var patients = await repo.GetAllP();
            return View(patients); 
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            await repo.AddPatient(patient);
            return RedirectToAction("GetAll");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var n = await repo.GetById(id);
            return View(n);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Patient patient)
        {

            await repo.Update(patient);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var docc = await repo.GetById(id);
            return View(docc);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Patient patient)
        {
            await repo.Delete(patient);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int ID)
        {
            var r = await repo.GetById(ID);

            return View(r);
        }



    }
}
