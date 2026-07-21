using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Entities;

namespace NutriFood.Infrastructure.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("menus");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(m => m.Path)
                .HasColumnName("path")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(m => m.Active)
                .HasColumnName("active")
                .HasDefaultValue(true);
        }
    }
}
