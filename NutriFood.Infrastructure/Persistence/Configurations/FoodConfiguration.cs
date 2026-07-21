using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class FoodConfiguration : AuditableConfiguration<Food>
    {
        public override void Configure(EntityTypeBuilder<Food> builder)
        {
            base.Configure(builder);

            builder.ToTable("foods");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(f => f.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(f => f.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(f => f.Description)
                .HasColumnName("description");

            builder.Property(f => f.FoodCategoryId)
                .HasColumnName("food_category_id");

            builder.Property(f => f.FoodClassificationId)
                .HasColumnName("food_classification_id");

            builder.Property(f => f.ImageUrl)
                .HasColumnName("image_url");

            builder.HasOne(f => f.FoodCategory)
                .WithMany(fc => fc.Foods)
                .HasForeignKey(f => f.FoodCategoryId);

            builder.HasOne(f => f.FoodClassification)
                .WithMany(fcl => fcl.Foods)
                .HasForeignKey(f => f.FoodClassificationId);

            builder.HasMany(f => f.FoodAttributeValues)
                .WithOne(fav => fav.Food)
                .HasForeignKey(fav => fav.FoodId);

            builder.HasMany(f => f.RecipeFoods)
                .WithOne(rf => rf.Food)
                .HasForeignKey(rf => rf.FoodId);
        }
    }
}
