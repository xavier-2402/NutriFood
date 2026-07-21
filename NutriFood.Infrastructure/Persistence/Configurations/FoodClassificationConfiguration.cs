using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class FoodClassificationConfiguration : IEntityTypeConfiguration<FoodClassification>
    {
        public void Configure(EntityTypeBuilder<FoodClassification> builder)
        {
            builder.ToTable("food_classifications");

            builder.HasKey(p => p.Id);

            builder.Property(fcl => fcl.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(p => p.Active)
                .HasColumnName("active")
                .HasDefaultValue(true);

            builder.HasMany(p => p.Foods)
                .WithOne(f => f.FoodClassification)
                .HasForeignKey(f => f.FoodClassificationId);
        }
    }
}
