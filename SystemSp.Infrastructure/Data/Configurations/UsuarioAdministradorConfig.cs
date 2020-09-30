using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class UsuarioAdministradorConfig : IEntityTypeConfiguration<UsuarioAdministrador>
    {
        public void Configure(EntityTypeBuilder<UsuarioAdministrador> builder)
        {
            builder.HasKey(e => e.IdAdmin)
                    .HasName("PK__UsuarioA__4C3F97F497744D61");

            builder.Property(e => e.TipoAdmin)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.UsuarioAdministrador)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAdmin");
        }
    }
}
