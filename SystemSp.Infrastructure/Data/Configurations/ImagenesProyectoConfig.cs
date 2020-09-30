using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class ImagenesProyectoConfig : IEntityTypeConfiguration<ImagenesProyecto>
    {
        public void Configure(EntityTypeBuilder<ImagenesProyecto> builder)
        {
            builder.HasKey(e => e.NumeroImagen)
                    .HasName("PK__Imagenes__AFF583C2B2CB5CD0");

            builder.Property(e => e.Imagen).IsRequired();

            builder.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.TipoImagen)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            builder.HasOne(d => d.IdProyectoNavigation)
                .WithMany(p => p.ImagenesProyecto)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImagesUser");
        }
    }
}
