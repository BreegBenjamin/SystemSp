using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class DetalleSolicitudConfig : IEntityTypeConfiguration<DetalleSolicitud>
    {
        public void Configure(EntityTypeBuilder<DetalleSolicitud> builder)
        {
            builder.HasKey(e => e.IdDetalle)
                    .HasName("PK__DetalleS__E43646A501D92E3B");

            builder.Property(e => e.DetalleDescripcion).IsUnicode(false);

            builder.HasOne(d => d.IdSolicitudNavigation)
                .WithMany(p => p.DetalleSolicitud)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK_Details");
        }
    }
}
