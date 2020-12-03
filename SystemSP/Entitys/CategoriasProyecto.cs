using Newtonsoft.Json;
using System.Collections.Generic;

namespace SystemSP.Entitys
{
    public class ListaCategoriaVista 
    {
        public ListaCategoriaVista(string _image, string _nombre) 
        {
            ImageCategoria = _image;
            NombreCategoria = _nombre;
        }
        public string ImageCategoria { get; set; }
        public string NombreCategoria { get; set; }
    }
}
