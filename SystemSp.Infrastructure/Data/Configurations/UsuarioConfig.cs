using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.IdUsuario)
                                .HasName("PK__Usuario__5B65BF9735A91B71");

            builder.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Contrasenia).IsUnicode(false);

            builder.Property(e => e.DireccionEmail).IsUnicode(false);

            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");

            builder.Property(e => e.ImagenUsuario).HasMaxLength(1);

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NumeroCelular)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.NumeroDocumento)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.TipoDocumento)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
        }
    }
}
