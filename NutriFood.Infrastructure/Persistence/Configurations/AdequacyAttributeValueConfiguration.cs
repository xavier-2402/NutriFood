using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class AdequacyAttributeValueConfiguration : AuditableConfiguration<AdequacyAttributeValue>
    {
        public override void Configure(EntityTypeBuilder<AdequacyAttributeValue> builder)
        {
            base.Configure(builder);

            builder.ToTable("adequacy_attribute_values");

            builder.HasKey(p => new { p.AdequacyPercentageId, p.AttributeId });

            builder.Property(aav => aav.AdequacyPercentageId)
                .HasColumnName("adequacy_percentage_id");

            builder.Property(p => p.AttributeId)
                .HasColumnName("attribute_id");

            builder.Property(p => p.Percentage)
                .HasColumnName("percentage")
                .HasColumnType("float");


            builder.HasOne(p => p.AdequacyPercentage)
                .WithMany(av => av.AdequacyAttributeValues)
                .HasForeignKey(ap => ap.AdequacyPercentageId);

            builder.HasOne(p => p.Attribute)
                .WithMany(aa => aa.AdequacyAttributeValues)
                .HasForeignKey(a => a.AttributeId);
        }
    }
}
