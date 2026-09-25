using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Contracts;

namespace NutriFood.Application.Validators
{
    public class PatientCreateRequestValidator : AbstractValidator<PatientCreateRequest>
    {
        public PatientCreateRequestValidator()
        {
            RuleFor(x => x.IdCard)
                .Matches(@"^\d{10}$")
                .WithMessage(ValidationMessages.IdCardFormat)
                .When(x => !string.IsNullOrWhiteSpace(x.IdCard));

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage(ValidationMessages.Required)
                .MaximumLength(100)
                .WithMessage(ValidationMessages.MaximumLength)
                .Matches(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\s]+$")
                .WithMessage(ValidationMessages.LettersOnly);


            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(ValidationMessages.Required)
                .MaximumLength(100)
                .WithMessage(ValidationMessages.MaximumLength)
                .Matches(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\s]+$")
                .WithMessage(ValidationMessages.LettersOnly);

            RuleFor(x => x.DateOfBirth)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage(ValidationMessages.DateCannotBeFuture);
        }
    }
}
