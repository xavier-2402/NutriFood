using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class MealPlanConfiguration : AuditableConfiguration<MealPlan>
    {
        public override void Configure(EntityTypeBuilder<MealPlan> builder)
        {
            base.Configure(builder);

            builder.ToTable("meal_plans");

            builder.HasKey(mp => mp.Id);

            builder.Property(mp => mp.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(mp => mp.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(mp => mp.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(mp => mp.Description)
                .HasColumnName("description");

            builder.Property(mp => mp.AdequacyPercentageId)
                .HasColumnName("adequacy_percentage_id");

            builder.HasOne(mp => mp.AdequacyPercentage)
                .WithMany(ap => ap.MealPlans)
                .HasForeignKey(mp => mp.AdequacyPercentageId);

            builder.HasMany(mp => mp.FoodMenus)
                .WithOne(fm => fm.MealPlan)
                .HasForeignKey(fm => fm.MealPlanId);
        }
    }
}
