using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SystemSP.Data
{
    public class ProyectosDestacados 
    {
        public List<TarjetasProyecto> CardElements { get; set; }
    }
    public class TarjetasProyecto 
    {
        public string ImageProyect { get; set; }
        public string ProyectTitle { get; set; }
        public string ImageUser { get; set; }
        public string NameUser { get; set; }
        public string ImageCategoria { get; set; }

    }
}
