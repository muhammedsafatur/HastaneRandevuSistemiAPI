namespace HastaneRandevuSistemiAPI.Models.Entities
{
    public class DoctorPatient
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string PatientTc { get; set; } // T.C. numarası
        public Patient Patient { get; set; }
    }
}
