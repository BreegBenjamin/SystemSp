using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class UsuarioCreadorSolicitudConfig : IEntityTypeConfiguration<UsuarioCreadorSolicitud>
    {
        public void Configure(EntityTypeBuilder<UsuarioCreadorSolicitud> builder)
        {
            builder.HasKey(e => e.IdCreacion)
                .HasName("PK__UsuarioC__05C53FB373C2784B");

            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");

            builder.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdCreadorNavigation)
                .WithMany(p => p.UsuarioCreadorSolicitud)
                .HasForeignKey(d => d.IdCreador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Creation");
        }
    }
}
