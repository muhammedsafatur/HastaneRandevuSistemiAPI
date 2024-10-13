using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.Repository.Abstract;

namespace HastaneRandevuSistemiAPI.DataAccesLayer.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public Task AddAsync(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment GetByDoc(int doctorId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Appointment> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
