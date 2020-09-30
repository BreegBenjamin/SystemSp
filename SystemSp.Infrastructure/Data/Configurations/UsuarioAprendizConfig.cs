using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class UsuarioAprendizConfig : IEntityTypeConfiguration<UsuarioAprendiz>
    {
        public void Configure(EntityTypeBuilder<UsuarioAprendiz> builder)
        {
            builder.HasKey(e => e.IdAprendiz)
                   .HasName("PK__UsuarioA__6C6328DD0633C1B6");

            builder.Property(e => e.CantidadProyectos)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.UsuarioAprendiz)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserApprentice");
        }
    }
}
