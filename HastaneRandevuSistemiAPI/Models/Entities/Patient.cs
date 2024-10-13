using HastaneRandevuSistemiAPI.Models.Dto.Patient.Request;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;

namespace HastaneRandevuSistemiAPI.Models.Entities
{
    public class Patient:Entity <Patient, string>
    {
        public string Tc { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public List<Appointment> Appointments { get; set; }=new List<Appointment>();
        public ICollection<DoctorPatient> DoctorPatients { get; set; } // Many-to-Many ilişkisi
        public Branch branch { get; set; }
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
