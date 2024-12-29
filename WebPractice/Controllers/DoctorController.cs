using Microsoft.AspNetCore.Mvc;
using WebPractice.Models.Entites;
using WebPractice.Repo.repo;

namespace WebPractice.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctor repo;
        public DoctorController(IDoctor repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> GetAll()
        {
            var n = await repo.GetAllD();
            return View(n);
            
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            await repo.AddDoctor(doctor);
            return RedirectToAction("GetAll");

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var n = await repo.GetById(id);
            return View(n);
        }
        [HttpPost]
        public  async Task<IActionResult> Update(Doctor doctor)
        {
           
            await repo.Updated(doctor);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var docc = await repo.GetById(id);
            return View(docc);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Delete(Doctor doctor)
        {
            await repo.Delete(doctor);
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
