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

        RuleFor(x => x.AppointmentDate)
            .NotEmpty().WithMessage("Appointment date cannot be empty.")
            .GreaterThan(DateTime.Now.AddDays(3)).WithMessage("Appointment date must be at least 3 days in the future.");
    }

    // İstenmeyen bir durum olduğu için GetId metodunu kaldırıyoruz.
    protected override int GetId(AddAppointmentRequestDto instance)
    {
        return 0; // Geçersiz, çünkü randevu için bir ID yok.
    }

    protected override DateTime GetDate(AddAppointmentRequestDto instance)
    {
        return instance.AppointmentDate; // AppointmentDate üzerinden doğrulama yapıyoruz.
    }
}
