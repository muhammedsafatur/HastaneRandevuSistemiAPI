namespace HastaneRandevuSistemiAPI.Models.Dto.Appointment.Request
{
    public class AddAppointmentRequestDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public string? PatientTc { get; set; }
    }
}
