using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repositories.Abstract;

namespace HastaneRandevuSistemiAPI.DataAccesLayer.Concrete
{
    public class PatientRepository : IPatientRepository
    {
        public Task AddAsync(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }



        public List<Patient> GetAllPatientsByDocBranch(Branch branch)
        {
            throw new NotImplementedException();
        }

     

        public List<Patient> GetAllPatientsByDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientbyTc(string tc)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
}
