using WebPractice.Models.Entites;

namespace WebPractice.Repo.repo
{
    public interface IPatient
    {
        public Task<IEnumerable<Patient>> GetAllP();

        public Task AddPatient(Patient patient);

        public Task Delete(Patient patient);
        public Task<Patient> GetById(int id);

        public Task Update(Patient patient);

    }
}
