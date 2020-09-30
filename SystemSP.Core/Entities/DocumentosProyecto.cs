using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class DocumentosProyecto
    {
        public int NumeroDocumento { get; set; }
        public int IdProyecto { get; set; }
        public string NombreDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public byte[] Documento { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
