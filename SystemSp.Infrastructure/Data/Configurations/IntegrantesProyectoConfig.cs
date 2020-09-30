using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class IntegrantesProyectoConfig : IEntityTypeConfiguration<IntegrantesProyecto>
    {
        public void Configure(EntityTypeBuilder<IntegrantesProyecto> builder)
        {
            builder.HasKey(e => e.IdPersona)
                    .HasName("PK__Integran__2EC8D2ACD5345475");

            builder.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdProyectoNavigation)
                .WithMany(p => p.IntegrantesProyecto)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project");
        }
    }
}
