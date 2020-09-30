using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class SolicitudEmpresaConfig : IEntityTypeConfiguration<SolicitudEmpresa>
    {
        public void Configure(EntityTypeBuilder<SolicitudEmpresa> builder)
        {
            builder.HasKey(e => e.IdSolicitud)
                                .HasName("PK__Solicitu__36899CEFC5932E7D");

            builder.Property(e => e.CategoriaRequerimiento)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Departamento)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.DescripcionRequerimiento).IsUnicode(false);

            builder.Property(e => e.FechaActualziacion).HasColumnType("datetime");

            builder.Property(e => e.FechaEliminacion).HasColumnType("datetime");

            builder.Property(e => e.FechaPublicacion).HasColumnType("datetime");

            builder.Property(e => e.NombreRequerimiento)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.SolicitudEmpresa)
                .HasForeignKey(d => d.IdCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestEmp");
        }
    }
}
