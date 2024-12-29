using Microsoft.AspNetCore.Mvc;
using WebPractice.Models;
using WebPractice.Repo.repo;

namespace WebPractice.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointment repo;
        private readonly IPatient Prepo;
        private readonly IDoctor drepo;

       public  AppointmentController(IAppointment Repo,IPatient Prepo,IDoctor Drepo)
        {
            this.repo = Repo;
            this.Prepo = Prepo;
            this.drepo = Drepo;
        }
        public async Task<IActionResult> Index()
        {
           var n= await repo.GetAllAp();
            return View(n);
        }

        public async Task<IActionResult> Create()
        {
            var pat =await Prepo.GetAllP();
            var Doc = await drepo.GetAllD();
            var r = new AppointmentViewModel()
            {
                patientList = pat,
                DoctorList = Doc,
            };
            return View(r);
        }
        [HttpPost]  
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            await repo.Addap(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, AppointmentViewModel model)
        {
            await repo.GetApById(id);
            var pat = await Prepo.GetAllP();
            var Doc = await drepo.GetAllD();
            var r = new AppointmentViewModel()
            {
                Date = model.Date,
                Notes = model.Notes,
                patientList = pat,
                DoctorList = Doc,
            };
            return View(r);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppointmentViewModel model, int id)
        {
            await repo.Updateap(model,id);
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public async Task<IActionResult> Details(int id)
        {
            var n =await  repo.GetApById(id);

            
            return View(n);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var n = await repo.GetApById(id);
            return View(n);
        }

        [HttpPost, ActionName("Delete")]
        public async Task <IActionResult> Delete(AppointmentViewModel model,int id)
        {
           await repo.Deleteap(model,id);
            return RedirectToAction("Index");
        }
    }

}
