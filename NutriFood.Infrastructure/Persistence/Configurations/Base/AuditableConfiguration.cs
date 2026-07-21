using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriFood.Domain.Common.Base;

namespace NutriFood.Infrastructure.Persistence.Configurations.Base
{
    public class AuditableConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Active)
                .HasColumnName("active")
                .HasDefaultValue(true);

            builder.Property(x => x.CreaDate)
                .HasColumnName("crea_date")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(x => x.CreaUsr)
                .HasColumnName("crea_usr");

            builder.Property(x => x.ModDate)
                .HasColumnName("mod_date")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()");

            builder.Property(x => x.ModUsr)
                .HasColumnName("mod_usr");
        }
    }
}
