using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSp.DTOS.EntitisProjectsApp
{
    public class ReportApp
    {
        public string NombreProyecto { get; set; }
        public string Categoria { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string Ciudad { get; set; }
    }
}
