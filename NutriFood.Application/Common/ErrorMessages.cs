namespace NutriFood.Application.Common;

public static class ErrorMessages
{
    public const string AdequacyPercentageNotFound = "Adequacy percentage does not exist.";
    public const string AdequacyPercentagePatientNotFound = "The adequacy percentage does not belong to an active patient for the current user.";
    public const string FoodMenuNotFound = "Food menu does not exist, is inactive, or does not belong to the current user.";
    public const string MealPlanNotFound = "Meal plan does not exist, is inactive, or does not belong to the current user.";
    public const string MealTimeNotFound = "Meal time does not exist or is inactive.";
    public const string PatientNotFound = "Patient does not exist";
}
