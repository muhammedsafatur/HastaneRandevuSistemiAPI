namespace HastaneRandevuSistemiAPI.Models.Entities
{
    public class Appointment:EntityBase<Appointment,Guid>
    {
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Title { get; set; }

        public string PatientTc { get; set; }
        public Patient Patient { get; set; }
    }
}
