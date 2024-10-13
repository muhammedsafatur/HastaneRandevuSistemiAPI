using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Entities.Enums;

namespace HastaneRandevuSistemiAPI.Models.Dto
{
    public class DoctorDto
    {public int Id { get; set; }
        public string? Name { get; set; }
        public Branch Branch { get; set; }
        public DRole Role { get; set; }
    }
}
