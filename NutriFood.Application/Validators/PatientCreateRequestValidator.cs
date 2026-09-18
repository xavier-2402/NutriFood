using FluentValidation;
using NutriFood.Application.Contracts;

namespace NutriFood.Application.Validators
{
    public class PatientCreateRequestValidator : AbstractValidator<PatientCreateRequest>
    {
        public PatientCreateRequestValidator()
        {
            RuleFor(x => x.IdCard)
                .Matches(@"^\d{10}$")
                .WithMessage("IdCard must contain exactly 10 digits.")
                .When(x => !string.IsNullOrWhiteSpace(x.IdCard));

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name cannot be empty.")
                .MaximumLength(100)
                .WithMessage("First name must be maximum 100 characters.");


            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.DateOfBirth)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("DateOfBirth cannot be a future date.");
        }
    }
}