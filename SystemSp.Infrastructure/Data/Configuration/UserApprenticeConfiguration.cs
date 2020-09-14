using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class UserApprenticeConfiguration : IEntityTypeConfiguration<UserApprentice>
    {
        public void Configure(EntityTypeBuilder<UserApprentice> builder)
        {
            builder.HasKey(e => e.IdApprendice)
                .HasName("PK__UserAppr__9E9B09A2C40F23BD");

            builder.Property(e => e.NumProject)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.UserApprentice)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserApprentice");
        }
    }
}
