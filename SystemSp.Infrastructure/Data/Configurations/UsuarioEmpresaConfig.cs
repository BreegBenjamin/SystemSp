using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    class UsuarioEmpresaConfig : IEntityTypeConfiguration<UsuarioEmpresa>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.HasKey(e => e.IdEmpresa)
                    .HasName("PK__UsuarioE__5EF4033EFC4FA6FD");

            builder.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.UsuarioEmpresa)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCompany");
        }
    }
}
