using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class IntegrantesProyecto
    {
        public int IdPersona { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
