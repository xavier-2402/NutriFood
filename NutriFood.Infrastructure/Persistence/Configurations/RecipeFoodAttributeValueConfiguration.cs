using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations;

public class RecipeFoodAttributeValueConfiguration : AuditableConfiguration<RecipeFoodAttributeValue>
{
    public override void Configure(EntityTypeBuilder<RecipeFoodAttributeValue> builder)
    {
        base.Configure(builder);

        builder.ToTable("recipe_food_attribute_values");

        builder.HasKey(value => new { value.RecipeId, value.FoodId, value.AttributeId });

        builder.Property(value => value.RecipeId)
            .HasColumnName("recipe_id");

        builder.Property(value => value.FoodId)
            .HasColumnName("food_id");

        builder.Property(value => value.AttributeId)
            .HasColumnName("attribute_id");

        builder.Property(value => value.Value)
            .HasColumnName("value");

        builder.HasOne(value => value.RecipeFood)
            .WithMany(recipeFood => recipeFood.RecipeFoodAttributeValues)
            .HasForeignKey(value => new { value.RecipeId, value.FoodId });

        builder.HasOne(value => value.Attribute)
            .WithMany(attribute => attribute.RecipeFoodAttributeValues)
            .HasForeignKey(value => value.AttributeId);
    }
}
