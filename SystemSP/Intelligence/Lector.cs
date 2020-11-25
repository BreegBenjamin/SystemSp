using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SystemSP.Entitys;
using SystemSP.I18nText;

namespace SystemSP.Intelligence
{
    public class Lector
    {
        public ListaCategoriaVista ObtenerListaCategorias() 
        {
            var categorias = new ListaCategoriaVista();
            try
            {
                string jsonResult = _jsonFile(@"wwwroot\json\vistaCategorias.json");
                categorias = (ListaCategoriaVista)JsonConvert.DeserializeObject(
                    jsonResult, typeof(ListaCategoriaVista));

            }
            catch{ }
            return categorias;
        }
        public List<ETecnologiasApp> GetTecnologiasApp(string tipo)
        {
            var listTech = new List<ETecnologiasApp>();
            string path = string.Empty;
            try
            {
                switch (tipo) 
                {
                    case "Front":
                        path = @"wwwroot\Json\TecnologiasFront.json";
                        break;
                    case "Back":
                        path = @"wwwroot\Json\TecnologiasBack.json";
                        break;
                    case "DataBase":
                        path = @"wwwroot\Json\TecnologiasDB.json";
                        break;
                    
                }
                string fileResult = _jsonFile(path);

                listTech = (List<ETecnologiasApp>)JsonConvert.DeserializeObject(
                    fileResult, typeof(List<ETecnologiasApp>));
            }
            catch (Exception ex){}
            return listTech;
        }
        private string _jsonFile(string archivoNombre) 
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), archivoNombre);
            return File.ReadAllText(path);
        }
    }
}
