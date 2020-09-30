using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class UsuarioAdministrador
    {
        public int IdAdmin { get; set; }
        public int IdUsuario { get; set; }
        public int? ProyectosPublicados { get; set; }
        public int? SolicitudesPublicadas { get; set; }
        public int? PostEliminados { get; set; }
        public string TipoAdmin { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
