namespace HastaneRandevuSistemiAPI.Models.Dto
{
    public class AppointmentResponseDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public string PatientTc { get; set; }
    }
}
