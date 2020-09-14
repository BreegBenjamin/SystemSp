using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class ImagesProjectConfiguration : IEntityTypeConfiguration<ImagesProject>
    {
        public void Configure(EntityTypeBuilder<ImagesProject> builder)
        {
            builder.HasKey(e => e.ImageNumber)
                .HasName("PK__ImagesPr__55C2C290E1C6171E");

            builder.Property(e => e.Imagen)
                .IsRequired()
                .HasColumnType("image");

            builder.HasOne(d => d.IdProjectNavigation)
                .WithMany(p => p.ImagesProject)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImagesUser");
        }
    }
}
