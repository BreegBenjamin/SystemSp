using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class TeamProjectConfiguration : IEntityTypeConfiguration<TeamProject>
    {
        public void Configure(EntityTypeBuilder<TeamProject> builder)
        {
            builder.HasKey(e => e.IdApprendice)
                .HasName("PK__TeamProj__9E9B09A212C0B634");

            builder.Property(e => e.LastNameAprendice)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.MailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NameApprendice)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdFirstUserNavigation)
                .WithMany(p => p.TeamProject)
                .HasForeignKey(d => d.IdFirstUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioCrador");

            builder.HasOne(d => d.IdProjectNavigation)
                .WithMany(p => p.TeamProject)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProyectoAprendiz");
        }
    }
}
