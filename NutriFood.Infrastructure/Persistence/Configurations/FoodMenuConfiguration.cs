using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class FoodMenuConfiguration : AuditableConfiguration<FoodMenu>
    {
        public override void Configure(EntityTypeBuilder<FoodMenu> builder)
        {
            base.Configure(builder);

            builder.ToTable("food_menus");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description");

            builder.Property(p => p.MealPlanId)
                .HasColumnName("meal_plan_id");

            builder.Property(p => p.MealTimeId)
                .HasColumnName("meal_time_id");

            builder.HasOne(p => p.MealPlan)
                .WithMany(mp => mp.FoodMenus)
                .HasForeignKey(fm => fm.MealPlanId);

            builder.HasOne(p => p.MealTime)
                .WithMany(mt => mt.FoodMenus)
                .HasForeignKey(fm => fm.MealTimeId);

            builder.HasMany(p => p.Recipes)
                .WithOne(r => r.FoodMenu)
                .HasForeignKey(r => r.FoodMenuId);
        }
    }
}
