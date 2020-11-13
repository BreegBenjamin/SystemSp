using Newtonsoft.Json;
using System.Collections.Generic;

namespace SystemSP.Entitys
{
    public class ListaCategoriaVista 
    {
        [JsonProperty("CategoriasVista")]
        public List<CategoriasVista> CategoriasVista { get; set; }
    }
    public class CategoriasVista 
    {
        [JsonProperty("ImageCategoria")]
        public string ImageCategoria { get; set; }
        [JsonProperty("NombreCategoria")]
        public string NombreCategoria { get; set; }
    }
}
