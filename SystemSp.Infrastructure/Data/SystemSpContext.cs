using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SystemSp.Core.Entities;
using SystemSp.Infrastructure.Data.Configuration;

namespace SystemSp.Infrastructure.Data
{
    public partial class SystemSpContext : DbContext
    {
        public SystemSpContext()
        {
        }

        public SystemSpContext(DbContextOptions<SystemSpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyRequest> CompanyRequest { get; set; }
        public virtual DbSet<DocumentProject> DocumentProject { get; set; }
        public virtual DbSet<FormativeProject> FormativeProject { get; set; }
        public virtual DbSet<ImagesProject> ImagesProject { get; set; }
        public virtual DbSet<LinkProject> LinkProject { get; set; }
        public virtual DbSet<TeamProject> TeamProject { get; set; }
        public virtual DbSet<UserAdmin> UserAdmin { get; set; }
        public virtual DbSet<UserApp> UserApp { get; set; }
        public virtual DbSet<UserApprentice> UserApprentice { get; set; }
        public virtual DbSet<UserCompany> UserCompany { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyRequestConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentProjectConfiguration());
            modelBuilder.ApplyConfiguration(new FormativeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ImagesProjectConfiguration());
            modelBuilder.ApplyConfiguration(new LinkProjectProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeamProjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserAdminConfiguration());
            modelBuilder.ApplyConfiguration(new UserAppConfiguration());
            modelBuilder.ApplyConfiguration(new UserApprenticeConfiguration());
            modelBuilder.ApplyConfiguration(new UserCompanyConfiguration());
        }

    }
}
