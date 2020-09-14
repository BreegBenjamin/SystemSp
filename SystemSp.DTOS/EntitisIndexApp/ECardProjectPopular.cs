using Newtonsoft.Json;

namespace SystemSp.DTOS.EntitisIndexApp
{
    public class TarjetasPopulares
    {
        [JsonProperty]
        public string Imagen { get; set; }
        [JsonProperty]
        public string Titulo { get; set; }
    }
}
