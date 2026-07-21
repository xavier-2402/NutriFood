using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class MealTimeConfiguration : IEntityTypeConfiguration<MealTime>
    {
        public void Configure(EntityTypeBuilder<MealTime> builder)
        {
            builder.ToTable("meal_times");

            builder.HasKey(mt => mt.Id);

            builder.Property(mt => mt.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(mt => mt.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(mt => mt.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(mt => mt.Active)
                .HasColumnName("active")
                .HasDefaultValue(true);

            builder.HasMany(mt => mt.FoodMenus)
                .WithOne(fm => fm.MealTime)
                .HasForeignKey(fm => fm.MealTimeId);
        }
    }
}
