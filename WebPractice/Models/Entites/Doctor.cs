using System.ComponentModel.DataAnnotations;

namespace WebPractice.Models.Entites
{
    public class Doctor
    {
        [Key]
        public int id {  get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }

        public ICollection<Appointment>? appointments { get; set; }

    }
}
