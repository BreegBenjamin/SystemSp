using Newtonsoft.Json;
using System.Collections.Generic;

namespace SystemSP.Entitys
{
    public class InformacionProyecto
    {
        [JsonProperty("CategoriasProyecto")]
        public List<CategoriasProyecto> CategoriasProyecto { get; set; }
    }
    public class ListaCategoriaVista 
    {
        [JsonProperty("CategoriasVista")]
        public List<CategoriasVista> CategoriasVista { get; set; }
    }
    public class CategoriasProyecto
    {
        [JsonProperty("ImgCategoria")]
        public string ImgCategoria { get; set; }
        [JsonProperty("TipoCategoria")]
        public string TipoCategoria { get; set; }
    }
    public class CategoriasVista 
    {
        [JsonProperty("ImageCategoria")]
        public string ImageCategoria { get; set; }
        [JsonProperty("NombreCategoria")]
        public string NombreCategoria { get; set; }
    }
    public class CategoriaSolicitud 
    {
        public string Nombre { get; set; }
        public string UrlImage { get; set; }
        public int IdCategoria { get; set; }
    }
}
