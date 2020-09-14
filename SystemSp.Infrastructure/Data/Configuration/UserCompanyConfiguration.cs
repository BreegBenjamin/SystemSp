using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
    {
        public void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            builder.HasKey(e => e.IdCompany)
                .HasName("PK__UserComp__3AF752DFDE6D4800");

            builder.Property(e => e.AddressCompany)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.UserCompany)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCompany");
        }
    }
}
