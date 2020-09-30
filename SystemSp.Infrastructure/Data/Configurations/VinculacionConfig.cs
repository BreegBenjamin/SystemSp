using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configurations
{
    class VinculacionConfig : IEntityTypeConfiguration<Vinculacion>
    {
        public void Configure(EntityTypeBuilder<Vinculacion> builder)
        {
            builder.HasKey(e => e.IdVinculacion)
                                .HasName("PK__Vinculac__8F3EB47AB45F8388");

            builder.Property(e => e.IdVinculacion).ValueGeneratedNever();

            builder.Property(e => e.FechaVinculacion).HasColumnType("datetime");

            builder.Property(e => e.NombreAprendiz)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.TipoVincualacion)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdAprendizNavigation)
                .WithMany(p => p.Vinculacion)
                .HasForeignKey(d => d.IdAprendiz)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinkUser");

            builder.HasOne(d => d.IdEmpresaNavigation)
                .WithMany(p => p.Vinculacion)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinkEmp");

            builder.HasOne(d => d.IdProyectoNavigation)
                .WithMany(p => p.Vinculacion)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinkProject");
        }
    }
}
