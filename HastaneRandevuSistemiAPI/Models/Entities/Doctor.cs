using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Models.Entities;

public class Doctor : Entity<int>
{
    public Branch Branch { get; set; }
    public DRole Role { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
