using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SystemSP.Data;
using SystemSP.Entitys;
using DTOSystemSp.EntitysInicioApp;
using SystemSP.I18nText;

namespace SystemSP.Intelligence
{
    public class Lector
    {
        public ProyectosDestacados ObtenerProyectos() 
        {
            var proyecto = new ProyectosDestacados();
            try
            {
                string jsonResult = _jsonFile(@"Data\carproyectos.json");
                proyecto = (ProyectosDestacados)JsonConvert.DeserializeObject(
                    jsonResult, typeof(ProyectosDestacados));
            }
            catch (Exception ex) { }
            return proyecto;
        }
        public ListaCategoriaVista ObtenerListaCategorias() 
        {
            var categorias = new ListaCategoriaVista();
            try
            {
                string jsonResult = _jsonFile(@"Data\vistaCategorias.json");
                categorias = (ListaCategoriaVista)JsonConvert.DeserializeObject(
                    jsonResult, typeof(ListaCategoriaVista));

            }
            catch (Exception ex) { }
            return categorias;
        }
        public List<ETecnologiasApp> GetTecnologiasApp(string tipo)
        {
            var listTech = new List<ETecnologiasApp>();
            string path = string.Empty;

            if (tipo == "Front")
                path = @"wwwroot\Json\TecnologiasFront.json";
            try
            {
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
