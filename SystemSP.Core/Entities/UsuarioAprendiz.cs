using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class UsuarioAprendiz
    {
        public UsuarioAprendiz()
        {
            Vinculacion = new HashSet<Vinculacion>();
        }

        public int IdAprendiz { get; set; }
        public int IdUsuario { get; set; }
        public int CantidadProyectos { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Vinculacion> Vinculacion { get; set; }
    }
}
