using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioAdministrador = new HashSet<UsuarioAdministrador>();
            UsuarioAprendiz = new HashSet<UsuarioAprendiz>();
            UsuarioCreadorProyecto = new HashSet<UsuarioCreadorProyecto>();
            UsuarioCreadorSolicitud = new HashSet<UsuarioCreadorSolicitud>();
            UsuarioEmpresa = new HashSet<UsuarioEmpresa>();
        }

        public int IdUsuario { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroCelular { get; set; }
        public string DireccionEmail { get; set; }
        public string Contrasenia { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? TipoUsuario { get; set; }
        public byte[] ImagenUsuario { get; set; }

        public virtual ICollection<UsuarioAdministrador> UsuarioAdministrador { get; set; }
        public virtual ICollection<UsuarioAprendiz> UsuarioAprendiz { get; set; }
        public virtual ICollection<UsuarioCreadorProyecto> UsuarioCreadorProyecto { get; set; }
        public virtual ICollection<UsuarioCreadorSolicitud> UsuarioCreadorSolicitud { get; set; }
        public virtual ICollection<UsuarioEmpresa> UsuarioEmpresa { get; set; }
    }
}
