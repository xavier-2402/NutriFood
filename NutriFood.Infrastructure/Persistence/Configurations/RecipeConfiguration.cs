using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("recipes");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(r => r.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(r => r.Description)
                .HasColumnName("description");

            builder.Property(r => r.FoodMenuId)
                .HasColumnName("food_menu_id");

            builder.HasOne(r => r.FoodMenu)
                .WithMany(fm => fm.Recipes)
                .HasForeignKey(r => r.FoodMenuId);

            builder.HasMany(r => r.RecipeFoods)
                .WithOne(rf => rf.Recipe)
                .HasForeignKey(rf => rf.RecipeId);
        }
    }
}
