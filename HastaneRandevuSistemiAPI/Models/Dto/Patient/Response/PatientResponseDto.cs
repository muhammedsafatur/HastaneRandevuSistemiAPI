using HastaneRandevuSistemiAPI.Models.Entities;

namespace HastaneRandevuSistemiAPI.Models.Dto.Patient.Response;

public class PatientResponseDto
{
    public string? Tc { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

   /* public static implicit operator PatientResponseDto(PatientResponseDto patient)
    {
        return new PatientResponseDto
        {
            Tc = patient.Tc,
            Name = patient.Name,
            Email = patient.Email,
            Phone = patient.Phone,
        };
    }*/
}
