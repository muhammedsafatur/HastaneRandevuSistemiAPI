namespace HastaneRandevuSistemiAPI.Models.Entities
{
    public class Patient:EntityBase <Patient, string>
    {
        public string Tc { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Appointment> Appointments { get; set; }=new List<Appointment>();
      
    }
}
