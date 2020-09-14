using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class LinkProjectProjectConfiguration : IEntityTypeConfiguration<LinkProject>
    {
        public void Configure(EntityTypeBuilder<LinkProject> builder)
        {
            builder.HasKey(e => e.IdLink)
                .HasName("PK__LinkProj__31D8A6ED0491E497");

            builder.Property(e => e.ApprendiceName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.DateLinked).HasColumnType("datetime");

            builder.HasOne(d => d.IdCompanyNavigation)
                .WithMany(p => p.LinkProject)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK_VinculoEmp");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.LinkProject)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_VinculoUser");
        }
    }
}
