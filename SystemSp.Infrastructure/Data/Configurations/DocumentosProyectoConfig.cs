using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    public class DocumentosProyectoConfig : IEntityTypeConfiguration<DocumentosProyecto>
    {
        public void Configure(EntityTypeBuilder<DocumentosProyecto> builder)
        {
            builder.HasKey(e => e.NumeroDocumento)
                    .HasName("PK__Document__A4202589D7F4A274");

            builder.Property(e => e.NombreDocumento)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.TipoDocumento)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.NombreContenedor)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(false);

            builder.HasOne(d => d.IdProyectoNavigation)
                .WithMany(p => p.DocumentosProyecto)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentUser");
        }
    }
}
