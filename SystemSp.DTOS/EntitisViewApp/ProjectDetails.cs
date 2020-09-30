using System;
using System.Collections.Generic;
using System.Text;
using SystemSp.DTOS.EntitisFormsApp;

namespace SystemSp.DTOS.EntitisViewApp
{
    public class ProjectDetails
    {
        public string NombreProyecto { get; set; }
        public string NumeroDescargas { get; set; }
        public string NumeroVistas { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int IdProyecto { get; set; }
        public bool Process { get; set; }
        public List<ApprenticeData> Aprendices  { get; set; }
        public List<string> ImagenesProyecto { get; set; }
    }
}
