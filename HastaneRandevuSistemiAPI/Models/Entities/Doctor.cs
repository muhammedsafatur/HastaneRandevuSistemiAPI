namespace HastaneRandevuSistemiAPI.Models.Entities;

public class Doctor:EntityBase<Doctor,int>
{

    public Branch Branch { get; set; }
   
    public string AppointmentId { get; set; } = string.Empty;
    public List<Appointment> Appointments { get; set; }= new List<Appointment>();
}
