using System;
using System.Collections.Generic;

namespace SystemSp.Core.Entities
{
    public partial class TecnologiasUtilizadas
    {
        public int Tech { get; set; }
        public int IdProyecto { get; set; }
        public string TecnologiasFront { get; set; }
        public string TecnologiasBack { get; set; }
        public string TecnologiasDb { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
