using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class ImagenesSolicitudConfig : IEntityTypeConfiguration<ImagenesSolicitud>
    {
        public void Configure(EntityTypeBuilder<ImagenesSolicitud> builder)
        {
            builder.HasKey(e => e.NumeroImagen)
                .HasName("PK__Imagenes__AFF583C2E00EF791");

            builder.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.TipoImagen)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.NombreContenedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.ImagenOriginal)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdSolicitudNavigation)
                .WithMany(p => p.ImagenesSolicitud)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK_ImagesRequest");
        }
    }
}
