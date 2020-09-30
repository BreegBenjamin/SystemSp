using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class UsuarioCreadorProyecto
    {
        public UsuarioCreadorProyecto()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdCreacion { get; set; }
        public int IdCreador { get; set; }
        public string NombreUsuario { get; set; }
        public int? TipoUsuario { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Usuario IdCreadorNavigation { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
