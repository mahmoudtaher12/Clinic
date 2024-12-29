using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System;
using WebPractice.Models;
using WebPractice.Models.Entites;
using WebPractice.Repo.repo;

    public class PatientRepo : IPatient
    {
        private readonly AppDbContext _appDbContext;
    public PatientRepo(AppDbContext _appDbContext)
    {
        this._appDbContext = _appDbContext;
    }
    public async Task AddPatient(Patient patient)
        {
            await _appDbContext.Patients.AddAsync(patient);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Patient patient)
        {
            _appDbContext.Patients.Remove(patient);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllP()
        {
            var r = await _appDbContext.Patients.ToListAsync();
            return r;
        }

       

        public async Task Update(Patient patient)
        {
            _appDbContext.Update(patient);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Patient>GetById(int id)
        {
            var n = await _appDbContext.Patients.FirstOrDefaultAsync(x => x.PatientId == id);
            return n;
        }
    }