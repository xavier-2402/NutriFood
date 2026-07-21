using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class AdequacyPercentageConfiguration : AuditableConfiguration<AdequacyPercentage>
    {
        public override void Configure(EntityTypeBuilder<AdequacyPercentage> builder)
        {
            base.Configure(builder);

            builder.ToTable("adequacy_percentage");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description");

            builder.Property(p => p.PatientId)
                .HasColumnName("patient_id");

            builder.HasOne(p => p.Patient)
                .WithMany(p => p.AdequacyPercentages)
                .HasForeignKey(p => p.PatientId);

            builder.HasMany(p => p.AdequacyAttributeValues)
                .WithOne(ap => ap.AdequacyPercentage)
                .HasForeignKey(aav => aav.AdequacyPercentageId);

            builder.HasMany(p => p.MealPlans)
                .WithOne(mp => mp.AdequacyPercentage)
                .HasForeignKey(mp => mp.AdequacyPercentageId);
        }
    }
}
