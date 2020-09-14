using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class UserAdminConfiguration : IEntityTypeConfiguration<UserAdmin>
    {
        public void Configure(EntityTypeBuilder<UserAdmin> builder)
        {
            builder.HasKey(e => e.IdAdmin)
                .HasName("PK__UserAdmi__4C3F97F4EAC28DEE");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.UserAdmin)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAdmin");
        }
    }
}
