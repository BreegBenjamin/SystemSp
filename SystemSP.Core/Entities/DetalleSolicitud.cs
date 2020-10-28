using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class DetalleSolicitud
    {
        public int IdDetalle { get; set; }
        public int? IdSolicitud { get; set; }
        public string DetalleDescripcion { get; set; }
        public string NombreDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreContenedor { get; set; }

        public virtual SolicitudEmpresa IdSolicitudNavigation { get; set; }
    }
}
