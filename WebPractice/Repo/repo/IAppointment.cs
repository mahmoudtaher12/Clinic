using WebPractice.Models;
using WebPractice.Models.Entites;

namespace WebPractice.Repo.repo
{
    public interface IAppointment
    {
        public Task<IEnumerable<Appointment>> GetAllAp();

        public Task<Appointment> GetApById(int id);

        public Task Addap(AppointmentViewModel appointment);

        public Task Deleteap(AppointmentViewModel appointment, int id);
        public Task Updateap(AppointmentViewModel appointment,int id);
    }
}
