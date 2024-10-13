using FluentValidation;
using HastaneRandevuSistemiAPI.Models.Dto.Patient.Request;

public class PatientValidator : BaseValidator<AddPatientRequestDto>
{
    public PatientValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.");

        RuleFor(x => x.Tc)
            .NotEmpty().WithMessage("TC cannot be empty.")
            .Matches(@"^\d{11}$").WithMessage("TC must be exactly 11 digits.");
    }

    protected override int GetId(AddPatientRequestDto instance)
    {
        return 0; // veya uygun bir değer döndürülmeli.
    }

    protected override DateTime GetDate(AddPatientRequestDto instance)
    {
        // Eğer hasta için tarih yoksa, varsayılan bir değer döndürüyoruz.
        return DateTime.MinValue;
    }
}
