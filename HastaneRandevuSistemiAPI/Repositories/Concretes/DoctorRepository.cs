using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repositories.Abstract;

namespace HastaneRandevuSistemiAPI.DataAccesLayer.Concrete
{
    public class DoctorRepository : IDoctorRepository
    {
        public Task AddAsync(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Doctor GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Doctor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
