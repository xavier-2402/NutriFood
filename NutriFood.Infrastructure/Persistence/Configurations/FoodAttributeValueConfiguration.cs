using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class FoodAttributeValueConfiguration : AuditableConfiguration<FoodAttributeValue>
    {
        public override void Configure(EntityTypeBuilder<FoodAttributeValue> builder)
        {
            base.Configure(builder);

            builder.ToTable("food_attribute_values");

            builder.HasKey(p => new { p.FoodId, p.AttributeId });

            builder.Property(p => p.FoodId)
                .HasColumnName("food_id");

            builder.Property(p => p.AttributeId)
                .HasColumnName("attribute_id");

            builder.Property(p => p.Value)
                .HasColumnName("value");


            builder.HasOne(p => p.Food)
                .WithMany(f => f.FoodAttributeValues)
                .HasForeignKey(fav => fav.FoodId);

            builder.HasOne(p => p.Attribute)
                .WithMany(fa => fa.FoodAttributeValues)
                .HasForeignKey(fav => fav.AttributeId);
        }
    }
}
