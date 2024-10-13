using HastaneRandevuSistemiAPI.Models.Entities.Enums;

namespace HastaneRandevuSistemiAPI.Models.Entities;

public class Doctor : Entity<Doctor, int>
{
    public Branch Branch { get; set; }
    public DRole Role { get; set; }

    public Guid AppointmentId { get; set; } 

    
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<DoctorPatient> DoctorPatients { get; set; } = new List<DoctorPatient>(); // Many-to-Many ilişkisi
}
