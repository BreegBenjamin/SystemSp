using Newtonsoft.Json;
using System.Collections.Generic;

namespace DTOSystemSp.EntitysInicioApp
{
    public class ECardProjectPopular
    {
        public List<TarjetasPopulares> TarjetasPopulares { get; set; }
    }
    public class TarjetasPopulares
    {
        [JsonProperty("Imagen")]
        public string Imagen { get; set; }
        [JsonProperty("Titulo")]
        public string Titulo { get; set; }
    }
}
