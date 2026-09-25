namespace NutriFood.Application.Common;

public static class ValidationMessages
{
    public const string Required = "{PropertyName} cannot be empty.";
    public const string MaximumLength = "{PropertyName} must be maximum {MaxLength} characters.";
    public const string GreaterThanZero = "{PropertyName} must be greater than zero.";
    public const string GreaterThanOrEqualToZero = "{PropertyName} must be greater than or equal to zero.";
    public const string GramMeasureUnitRequired = "MeasureUnitId must reference grams (g).";
    public const string DuplicateAttributeIds = "AttributeIds cannot be duplicated.";
    public const string IdCardFormat = "IdCard must contain exactly 10 digits.";
    public const string LettersOnly = "{PropertyName} must not contain special characters.";
    public const string DateCannotBeFuture = "DateOfBirth cannot be a future date.";
}
