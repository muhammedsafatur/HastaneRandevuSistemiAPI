using HastaneRandevuSistemiAPI.Models.Entities.Enums;

namespace HastaneRandevuSistemiAPI.Models.Dto.Doctor.Request
{
    public class AddDoctorRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Branch Branch { get; set; }
        public DRole Role { get; set; }
    }
}
