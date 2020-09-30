using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class UsuarioEmpresa
    {
        public UsuarioEmpresa()
        {
            Vinculacion = new HashSet<Vinculacion>();
        }

        public int IdEmpresa { get; set; }
        public int IdUsuario { get; set; }
        public string NombreEmpresa { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int? CantidadSolicitudes { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Vinculacion> Vinculacion { get; set; }
    }
}
