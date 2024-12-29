using Microsoft.EntityFrameworkCore;
using WebPractice.Models;
using WebPractice.Models.Entites;
using WebPractice.Repo.repo;

namespace WebPractice.Repo.Implemintation
{
    public class ImpelementationRepo : IAppointment
    {
        public AppDbContext AppDbContext;
        public ImpelementationRepo(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public async Task Addap(AppointmentViewModel appointment)
        {
            var n = new Appointment()
            {
                Date = appointment.Date,
                Notes = appointment.Notes,
                PId = appointment.Pid,
                Did = appointment.Did,

            };
            await AppDbContext.Appointments.AddAsync(n);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task Deleteap(AppointmentViewModel appointment,int id)
        {
            var app = AppDbContext.Appointments.FirstOrDefault(x => x.AppointmentId == id);
            AppDbContext.Appointments.Remove(app);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAp()
        {
            var r = await AppDbContext.Appointments.ToListAsync();
            return r;
        }

        public async Task<Appointment> GetApById(int id)
        {
            var n = await AppDbContext.Appointments.Include(n => n.Doctor).Include(p => p.Patient).FirstOrDefaultAsync(x => x.AppointmentId == id);
            return n;
        }

        public async Task Updateap(AppointmentViewModel appointment,int id)
        {
            var app = AppDbContext.Appointments.FirstOrDefault(x => x.AppointmentId == id);
          
             app.Date = appointment.Date;
               app.Notes = appointment.Notes;
                app.PId = appointment.Pid;
            app.Did = appointment.Did;
           
            AppDbContext.Appointments.Update(app);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
