using FluentValidation;
using HastaneRandevuSistemiAPI.Models.Dto.Patient.Request;

public class PatientValidator : AbstractValidator<AddPatientRequestDto>
{
    public PatientValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.");

        RuleFor(x => x.Tc)
            .NotEmpty().WithMessage("TC cannot be empty.")
            .Matches(@"^\d{11}$").WithMessage("TC must be exactly 11 digits.");
    }
}
