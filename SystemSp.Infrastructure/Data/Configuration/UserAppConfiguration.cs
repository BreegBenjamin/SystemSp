using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.HasKey(e => e.IdUser)
                .HasName("PK__UserApp__B7C9263837A610E9");

            builder.Property(e => e.EmaiAddress)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.IdentificationNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.IdentificationType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.UserLastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.ImageUser)
                .HasColumnType("ImageUser");

            builder.Property(e => e.DateCreation).HasColumnType("datetime");
        }
    }
}
