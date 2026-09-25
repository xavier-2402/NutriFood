using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Contracts;

namespace NutriFood.Application.Validators;

public sealed class AdequacyPercentageCreateRequestValidator : AbstractValidator<AdequacyPercentageCreateRequest>
{
    public AdequacyPercentageCreateRequestValidator()
    {
        RuleFor(request => request.Title)
            .Must(title => !string.IsNullOrWhiteSpace(title))
            .WithMessage(ValidationMessages.Required)
            .MaximumLength(250)
            .WithMessage(ValidationMessages.MaximumLength);

        RuleFor(request => request.PatientId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero);

        RuleFor(request => request.AttributeValues)
            .NotNull()
            .WithMessage(ValidationMessages.Required)
            .Must(values => values is null || values.Select(value => value.AttributeId).Distinct().Count() == values.Count)
            .WithMessage(ValidationMessages.DuplicateAttributeIds);

        RuleForEach(request => request.AttributeValues)
            .SetValidator(new AdequacyAttributeValueCreateRequestValidator());
    }
}
