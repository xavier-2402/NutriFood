using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id)
                .HasName("users_pkey");

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Code)
                .HasColumnName("code")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("Password")
                .IsRequired();

            builder.Property(u => u.Active)
                .HasColumnName("active")
                .IsRequired();

            builder.Property(u => u.CreaDate)
                .HasColumnName("crea_date")
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder.Property(u => u.ModDate)
                .HasColumnName("mod_date")
                .HasColumnType("timestamp without time zone")
                .IsRequired();


            builder.HasMany(u => u.Patients)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}
