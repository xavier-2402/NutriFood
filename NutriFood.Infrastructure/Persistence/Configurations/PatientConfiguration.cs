using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;
using NutriFood.Infrastructure.Persistence.Configurations.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class PatientConfiguration : AuditableConfiguration<Patient>
    {
        public override void Configure(EntityTypeBuilder<Patient> builder)
        {
            base.Configure(builder);

            builder.ToTable("patients");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.IdCard)
                .HasColumnName("id_card")
                .HasMaxLength(25);

            builder.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .IsRequired();

            builder.Property(p => p.DateOfBirth)
                .HasColumnName("date_of_birth")
                .HasColumnType("timestamp without time zone");

            builder.Property(p => p.UserId)
                .HasColumnName("user_id");

            builder.HasOne(p => p.User)
                .WithMany(u => u.Patients)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.AdequacyPercentages)
                .WithOne(ap => ap.Patient)
                .HasForeignKey(ap => ap.PatientId);
        }
    }
}
