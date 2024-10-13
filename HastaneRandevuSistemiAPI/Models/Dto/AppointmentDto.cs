namespace HastaneRandevuSistemiAPI.Models.Dto
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public string PatientTc { get; set; }
    }
}
