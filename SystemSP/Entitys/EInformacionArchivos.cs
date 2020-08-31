using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemSP.Entitys
{
    public class EInformacionArchivos
    {
        public List<EArchivosProjecto> Archivos { get; set; }
        public List<string> ListaArchivos { get; set; }
        public int NumeroImagenes { get; set; }
        public int NumeroArchivos { get; set; }
    }
    public class EArchivosProjecto
    {
        public string ImageSrc { get; set; }
        public string FileName { get; set; }
    }
}
