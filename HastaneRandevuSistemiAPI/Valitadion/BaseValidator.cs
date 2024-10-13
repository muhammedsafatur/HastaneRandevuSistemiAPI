using FluentValidation;

public abstract class BaseValidator<T> : AbstractValidator<T>
{
    protected BaseValidator()
    {
        // ID alanı için genel doğrulama
        RuleFor(x => GetId(x))
            .NotEmpty().WithMessage("ID cannot be empty.")
            .GreaterThan(0).WithMessage("ID must be greater than zero.");

        // Tarih alanı için genel doğrulama (örneğin, randevu tarihleri)
        RuleFor(x => GetDate(x))
            .NotEmpty().WithMessage("Date cannot be empty.")
            .GreaterThan(DateTime.Now).WithMessage("Date must be in the future.");
    }

    protected abstract int GetId(T instance);
    protected abstract DateTime GetDate(T instance);
}
