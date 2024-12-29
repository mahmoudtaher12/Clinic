using Microsoft.EntityFrameworkCore;
using WebPractice.Models.Entites;

namespace WebPractice.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(x => x.Doctor)
                .WithMany(y => y.appointments)
                .HasForeignKey(x => x.Did);

            modelBuilder.Entity<Appointment>()
                .HasOne(x => x.Patient)
                .WithMany(y => y.appointments)
                .HasForeignKey(o => o.PId);
        }
    }
}
