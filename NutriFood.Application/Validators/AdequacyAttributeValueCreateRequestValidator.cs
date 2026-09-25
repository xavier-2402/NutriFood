using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Contracts;

namespace NutriFood.Application.Validators;

public sealed class AdequacyAttributeValueCreateRequestValidator : AbstractValidator<AdequacyAttributeValueCreateRequest>
{
    public AdequacyAttributeValueCreateRequestValidator()
    {
        RuleFor(request => request.AttributeId)
            .GreaterThan((short)0)
            .WithMessage(ValidationMessages.GreaterThanZero);

        RuleFor(request => request.Percentage)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ValidationMessages.GreaterThanOrEqualToZero);
    }
}
