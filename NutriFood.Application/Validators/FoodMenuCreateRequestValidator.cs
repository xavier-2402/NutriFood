using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Contracts;

namespace NutriFood.Application.Validators;

public sealed class FoodMenuCreateRequestValidator : AbstractValidator<FoodMenuCreateRequest>
{
    public FoodMenuCreateRequestValidator()
    {
        RuleFor(request => request.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage(ValidationMessages.Required)
            .MaximumLength(250)
            .WithMessage(ValidationMessages.MaximumLength);

        RuleFor(request => request.MealPlanId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero);

        RuleFor(request => request.MealTimeId)
            .GreaterThan((short)0)
            .When(request => request.MealTimeId.HasValue)
            .WithMessage(ValidationMessages.GreaterThanZero);
    }
}
