using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class ImagenesProyecto
    {
        public int NumeroImagen { get; set; }
        public int IdProyecto { get; set; }
        public string NombreImagen { get; set; }
        public string TipoImagen { get; set; }
        public string NombreContenedor { get; set; }
        public string ImagenOriginal { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
