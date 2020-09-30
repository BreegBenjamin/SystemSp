using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class UsuarioCreadorProyectoConfig : IEntityTypeConfiguration<UsuarioCreadorProyecto>
    {
        public void Configure(EntityTypeBuilder<UsuarioCreadorProyecto> builder)
        {
            builder.HasKey(e => e.IdCreacion)
                .HasName("PK__UsuarioC__05C53FB317453D6F");

            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");

            builder.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdCreadorNavigation)
                .WithMany(p => p.UsuarioCreadorProyecto)
                .HasForeignKey(d => d.IdCreador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreationProject");
        }
    }
}
