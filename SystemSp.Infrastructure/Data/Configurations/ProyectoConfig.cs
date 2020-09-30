using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class ProyectoConfig : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.HasKey(e => e.IdProyecto)
                    .HasName("PK__Proyecto__F4888673CEB7A22A");

            builder.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DescripcionProyecto).IsUnicode(false);

            builder.Property(e => e.FechaActualizacion).HasColumnType("datetime");

            builder.Property(e => e.FechaEliminado).HasColumnType("datetime");

            builder.Property(e => e.FechaFormacion).HasColumnType("datetime");

            builder.Property(e => e.FechaPublicacion).HasColumnType("datetime");

            builder.Property(e => e.NombreProyecto)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NombreSena)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Proyecto)
                .HasForeignKey(d => d.IdCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectdUser");
        }
    }
}
