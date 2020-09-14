using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class DocumentProjectConfiguration : IEntityTypeConfiguration<DocumentProject>
    {
        public void Configure(EntityTypeBuilder<DocumentProject> builder)
        {
            builder.HasKey(e => e.NumberDocument)
                .HasName("PK__Document__900E0D90143E4E8A");

            builder.Property(e => e.Document).IsRequired();

            builder.HasOne(d => d.IdProjectNavigation)
                .WithMany(p => p.DocumentProject)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentUser");
        }
    }
}
