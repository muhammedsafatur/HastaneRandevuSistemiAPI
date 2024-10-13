using FluentValidation;
using HastaneRandevuSistemiAPI.Models.Dto.Appointment.Request;

public class AppointmentValidator : BaseValidator<AddAppointmentRequestDto>
{
    public AppointmentValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doctor ID cannot be empty.");

        RuleFor(x => x.PatientTc)
            .NotEmpty().WithMessage("Patient TC cannot be empty.")
            .Matches(@"^\d{11}$").WithMessage("Patient TC must be exactly 11 digits.");
    }

    protected override int GetId(AddAppointmentRequestDto instance)
    {
        // Randevu için bir ID olmadığı için varsayılan bir değer döndürüyoruz.
        return 0; // veya uygun bir değer döndürülmeli.
    }

    protected override DateTime GetDate(AddAppointmentRequestDto instance)
    {
        return instance.AppointmentDate; // AppointmentDate üzerinden doğrulama yapıyoruz.
    }
}
