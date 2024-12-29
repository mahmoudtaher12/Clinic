using WebPractice.Models.Entites;
using WebPractice.Repo.Implemintation;

namespace WebPractice.Repo.repo
{
    public interface IDoctor
    {
        public Task<IEnumerable<Doctor>> GetAllD();

        public Task AddDoctor(Doctor doctor);

        public Task Delete(Doctor doctor);
        public Task<Doctor> GetById(int id);

        public Task Updated(Doctor doctor);


    }
}
