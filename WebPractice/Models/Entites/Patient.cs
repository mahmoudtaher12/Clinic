using System.ComponentModel.DataAnnotations;

namespace WebPractice.Models.Entites
{
    public class Patient
    {
        [Key]
       public int  PatientId {  get; set; }
        public string? PatientName { get; set;}

        public int ? PatientAge { get; set; }
        
        public ICollection<Appointment> appointments { get; set; }
    }
}
