using Microsoft.EntityFrameworkCore;
using SystemSp.Core.Entities;

namespace SystemSp.Infrastructure.Data
{
    public partial class SystemSpContext : DbContext
    {
        public SystemSpContext(DbContextOptions<SystemSpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleSolicitud> DetalleSolicitud { get; set; }
        public virtual DbSet<DocumentosProyecto> DocumentosProyecto { get; set; }
        public virtual DbSet<ImagenesProyecto> ImagenesProyecto { get; set; }
        public virtual DbSet<ImagenesSolicitud> ImagenesSolicitud { get; set; }
        public virtual DbSet<IntegrantesProyecto> IntegrantesProyecto { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<SolicitudEmpresa> SolicitudEmpresa { get; set; }
        public virtual DbSet<TecnologiasUtilizadas> TecnologiasUtilizadas { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioAdministrador> UsuarioAdministrador { get; set; }
        public virtual DbSet<UsuarioAprendiz> UsuarioAprendiz { get; set; }
        public virtual DbSet<UsuarioCreadorProyecto> UsuarioCreadorProyecto { get; set; }
        public virtual DbSet<UsuarioCreadorSolicitud> UsuarioCreadorSolicitud { get; set; }
        public virtual DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }
        public virtual DbSet<Vinculacion> Vinculacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(SystemSpContext).Assembly);
    }
}
