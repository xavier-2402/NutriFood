namespace NutriFood.Domain.Entities;

public readonly record struct RecipeFoodAttributeValueKey(int RecipeId, int FoodId, short AttributeId);
