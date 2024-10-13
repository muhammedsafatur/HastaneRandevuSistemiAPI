using HastaneRandevuSistemiAPI.Models.Dto.Patient.Request;

namespace HastaneRandevuSistemiAPI.Models.Entities
{
    public class Patient:Entity <Patient, string>
    {
        public string Tc { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public List<Appointment> Appointments { get; set; }=new List<Appointment>();

        public static explicit operator Patient(AddPatientRequestDto dto)
        {
            return new Patient
            {
                Name = dto.Name,
                Surname=dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                
            };
        }
    }
}
