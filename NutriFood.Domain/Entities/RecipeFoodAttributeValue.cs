using NutriFood.Domain.Common.Base;

namespace NutriFood.Domain.Entities;

public class RecipeFoodAttributeValue : AuditableEntity
{
    public int RecipeId { get; set; }

    public int FoodId { get; set; }

    public short AttributeId { get; set; }

    public double Value { get; set; }

    public RecipeFood? RecipeFood { get; set; }

    public FoodAttribute? Attribute { get; set; }
}
