using FluentValidation;
using HastaneRandevuSistemiAPI.Models.Dto.Doctor.Request;

namespace HastaneRandevuSistemiAPI.Validation
{
    public class DoctorValidator : AbstractValidator<AddDoctorRequestDto>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Doctor ID cannot be empty.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Doctor name cannot be empty.");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Branch cannot be empty.");


            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Specialization cannot be empty.");
        }
    }
}
