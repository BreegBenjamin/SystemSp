using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class ImagenesSolicitud
    {
        public int NumeroImagen { get; set; }
        public int? IdSolicitud { get; set; }
        public string NombreImagen { get; set; }
        public string TipoImagen { get; set; }
        public byte[] Imagen { get; set; }

        public virtual SolicitudEmpresa IdSolicitudNavigation { get; set; }
    }
}
