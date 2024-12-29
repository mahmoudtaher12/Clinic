using WebPractice.Models.Entites;

namespace WebPractice.Models
{
    public class AppointmentViewModel
    {
        public int appointmentId { get; set; }  
        public int Did { get; set; }
        public int Pid { get; set; }
        public IEnumerable<Doctor>? DoctorList { get; set; }

        public IEnumerable<Patient>? patientList { get; set; }

        public DateTime Date {  get; set; }
        public string? Notes { get; set; }
    }
}
