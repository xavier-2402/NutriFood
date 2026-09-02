using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class RecipeFoodConfiguration : AuditableConfiguration<RecipeFood>
    {
        public override void Configure(EntityTypeBuilder<RecipeFood> builder)
        {
            base.Configure(builder);

            builder.ToTable("recipe_foods");

            builder.HasKey(recipeFood => new { recipeFood.RecipeId, recipeFood.FoodId });

            builder.Property(recipeFood => recipeFood.RecipeId)
                .HasColumnName("recipe_id");

            builder.Property(recipeFood => recipeFood.FoodId)
                .HasColumnName("food_id");

            builder.Property(recipeFood => recipeFood.Quantity)
                .HasColumnName("quantity");

            builder.Property(recipeFood => recipeFood.MeasureUnitId)
                .HasColumnName("measure_unit_id");

            builder.HasOne(recipeFood => recipeFood.Recipe)
                .WithMany(recipe => recipe.RecipeFoods)
                .HasForeignKey(recipeFood => recipeFood.RecipeId);

            builder.HasOne(recipeFood => recipeFood.Food)
                .WithMany(food => food.RecipeFoods)
                .HasForeignKey(recipeFood => recipeFood.FoodId);

            builder.HasOne(recipeFood => recipeFood.MeasureUnit)
                .WithMany(measureUnit => measureUnit.RecipeFoods)
                .HasForeignKey(recipeFood => recipeFood.MeasureUnitId);
        }
    }
}
