using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Repository.Abstract;

namespace HastaneRandevuSistemiAPI.Repositories.Abstract
{
    public interface IAppointmentRepository:IEntityRepository<Appointment,Guid>
    {
        Appointment GetByDoc(int doctorId);
        Appointment GetByDate(DateTime date);
        
    }
}
