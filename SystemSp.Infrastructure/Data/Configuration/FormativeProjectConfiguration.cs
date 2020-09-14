using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data.Configuration
{
    public class FormativeProjectConfiguration : IEntityTypeConfiguration<FormativeProject>
    {
        public void Configure(EntityTypeBuilder<FormativeProject> builder)
        {
            builder.HasKey(e => e.IdProject)
                .HasName("PK__Formativ__B9E13D24E16678A6");

            builder.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Departament)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DescriptionProject).IsUnicode(false);

            builder.Property(e => e.NameSena)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PostData).HasColumnType("datetime");

            builder.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.TechnologiesBackend).IsUnicode(false);

            builder.Property(e => e.TechnologiesDataBase).IsUnicode(false);

            builder.Property(e => e.TechnologiesFrontend).IsUnicode(false);

            builder.HasOne(d => d.IdUserNavigation)
                   .WithMany(p => p.FormativeProject)
                   .HasForeignKey(d => d.IdUser)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_ProjectdUser");
        }
    }
}
