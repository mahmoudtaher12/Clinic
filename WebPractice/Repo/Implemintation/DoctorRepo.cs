using Microsoft.EntityFrameworkCore;
using WebPractice.Models;
using WebPractice.Models.Entites;
using WebPractice.Repo.repo;

namespace WebPractice.Repo.Implemintation
{
    public class DoctorRepo : IDoctor
    {
        public readonly AppDbContext appDbContext;
        public DoctorRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        

        public async Task AddDoctor(Doctor doctor)
        {
            await appDbContext.Doctors.AddAsync(doctor);
            await appDbContext.SaveChangesAsync();
        }

        

        public async Task Delete(Doctor doctor)
        {
             appDbContext.Doctors.Remove(doctor);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAllD()
        {
            var r= await appDbContext.Doctors.ToListAsync();
            return r;
        }

        public async Task<Doctor> GetById(int id)
        {
            var n = await appDbContext.Doctors.FirstOrDefaultAsync(x => x.id == id );
            return n;
        }

        

       

        public async Task Updated(Doctor doctor)
        {
               appDbContext.Update(doctor);
            await appDbContext.SaveChangesAsync();
        }
    }
}
