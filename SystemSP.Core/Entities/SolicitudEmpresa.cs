using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class SolicitudEmpresa
    {
        public SolicitudEmpresa()
        {
            DetalleSolicitud = new HashSet<DetalleSolicitud>();
            ImagenesSolicitud = new HashSet<ImagenesSolicitud>();
        }

        public int IdSolicitud { get; set; }
        public int IdCreacion { get; set; }
        public int IdUsuario { get; set; }
        public string NombreRequerimiento { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string DescripcionRequerimiento { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public DateTime? FechaActualziacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public string EstadoVinculacion { get; set; }
        public string Estado { get; set; }
        public string CategoriaRequerimiento { get; set; }
        public string NombreContenedor { get; set; }

        public virtual UsuarioCreadorSolicitud IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetalleSolicitud> DetalleSolicitud { get; set; }
        public virtual ICollection<ImagenesSolicitud> ImagenesSolicitud { get; set; }
    }
}
