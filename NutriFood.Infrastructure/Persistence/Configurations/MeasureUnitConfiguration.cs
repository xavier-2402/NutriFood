using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class MeasureUnitConfiguration : IEntityTypeConfiguration<MeasureUnit>
    {
        public void Configure(EntityTypeBuilder<MeasureUnit> builder)
        {
            builder.ToTable("measure_units");

            builder.HasKey(mu => mu.Id);

            builder.Property(mu => mu.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(mu => mu.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(mu => mu.Abbreviation)
                .HasColumnName("abbreviation")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(mu => mu.Active)
                .HasColumnName("active")
                .HasDefaultValue(true);

            builder.HasMany(mu => mu.FoodAttributes)
                .WithOne(fa => fa.MeasureUnit)
                .HasForeignKey(fa => fa.MeasureUnitId);

            builder.HasMany(mu => mu.RecipeFoods)
                .WithOne(rf => rf.MeasureUnit)
                .HasForeignKey(rf => rf.MeasureUnitId);
        }
    }
}
