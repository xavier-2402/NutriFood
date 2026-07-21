using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class FoodAttributeConfiguration : IEntityTypeConfiguration<FoodAttribute>
    {
        public void Configure(EntityTypeBuilder<FoodAttribute> builder)
        {
            builder.ToTable("FoodAttributes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name");

            builder.Property(p => p.Description)
                .HasColumnName("description");

            builder.Property(p => p.MeasureUnitId)
                .HasColumnName("measure_unit_id");

            builder.HasOne(p => p.MeasureUnit)
                .WithMany(mu => mu.FoodAttributes)
                .HasForeignKey(fa => fa.MeasureUnitId);

            builder.HasMany(fa => fa.FoodAttributeValues)
                .WithOne(fav => fav.Attribute)
                .HasForeignKey(fav => fav.AttributeId);

            builder.HasMany(fa => fa.AdequacyAttributeValues)
                .WithOne(aav => aav.Attribute)
                .HasForeignKey(aav => aav.AttributeId);
        }
    }
}
