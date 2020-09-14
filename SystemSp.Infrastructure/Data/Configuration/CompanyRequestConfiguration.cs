using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class CompanyRequestConfiguration : IEntityTypeConfiguration<CompanyRequest>
    {
        public void Configure(EntityTypeBuilder<CompanyRequest> builder)
        {
            builder.HasKey(e => e.IdRequirement)
                    .HasName("PK__CompanyR__E3ED0BBF4A3A62D3");

            builder.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Department)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.DescriptionRequest).IsUnicode(false);

            builder.Property(e => e.NameRequest)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PublicationDate).HasColumnType("datetime");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.CompanyRequest)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_SolicitudEmp");
        }
    }
}
