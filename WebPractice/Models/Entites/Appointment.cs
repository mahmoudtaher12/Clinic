using System.ComponentModel.DataAnnotations;

namespace WebPractice.Models.Entites
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
        public int Did {  get; set; }
        public int PId { get; set; }
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

       
        
    }
}
