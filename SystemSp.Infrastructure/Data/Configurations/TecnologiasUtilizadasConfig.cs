using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    class TecnologiasUtilizadasConfig : IEntityTypeConfiguration<TecnologiasUtilizadas>
    {
        public void Configure(EntityTypeBuilder<TecnologiasUtilizadas> builder)
        {
            builder.HasKey(e => e.Tech)
                  .HasName("PK__Tecnolog__8F787F62031F9C12");

            builder.Property(e => e.TecnologiasBack)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.TecnologiasDb)
                .IsRequired()
                .HasColumnName("TecnologiasDB")
                .IsUnicode(false);

            builder.Property(e => e.TecnologiasFront)
                .IsRequired()
                .IsUnicode(false);

            builder.HasOne(d => d.IdProyectoNavigation)
                .WithMany(p => p.TecnologiasUtilizadas)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TechProject");
        }
    }
}
