using HastaneRandevuSistemiAPI.Models.Dto.Patient.Request;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Models.Entities;

public class Patient : Entity<string>
{
    public string Tc { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public Branch Branch { get; set; }

   
}
