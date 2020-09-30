using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class Vinculacion
    {
        public int IdVinculacion { get; set; }
        public int IdEmpresa { get; set; }
        public int IdAprendiz { get; set; }
        public int IdProyecto { get; set; }
        public DateTime? FechaVinculacion { get; set; }
        public string NombreAprendiz { get; set; }
        public string NombreEmpresa { get; set; }
        public string TipoVincualacion { get; set; }

        public virtual UsuarioAprendiz IdAprendizNavigation { get; set; }
        public virtual UsuarioEmpresa IdEmpresaNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
