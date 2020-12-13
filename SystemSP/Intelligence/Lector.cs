using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SystemSp.DTOS.EntitisFormsApp;
using SystemSP.Entitys;

namespace SystemSP.Intelligence
{
    public class Lector
    {
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
            catch (Exception ex) {
                string ms = ex.Message;
            }
            return listTech;
        }
        public List<FormRequest> ReadAllStream(Stream streamText, int userId, string userName)
            => _readAllStream(streamText, userId, userName);
        private string _jsonFile(string archivoNombre) 
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), archivoNombre);
            return File.ReadAllText(path);
        }
        private List<FormRequest> _readAllStream(Stream streamText, int userId, string userName) 
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Json\solicitudesSystemSP.txt");
            using (var text = new StreamReader(path)) 
            {
                try
                {
                    var salida = new List<FormRequest>();
                    string line;
                    int contador = 0;
                    string[] textArchivos = new string[5];
                    while ((line = text.ReadLine()) != null)
                    {
                        textArchivos[contador] = line;
                        contador++;
                        if (contador == 5)
                        {
                            salida.Add(new FormRequest()
                            {
                                RequestName = textArchivos[0],
                                Department = textArchivos[1],
                                City = textArchivos[2],
                                RequestDescription = textArchivos[3],
                                Category = textArchivos[4],
                                IdUser = userId,
                                UserName = userName
                            });
                            contador = 0;
                        }

                    }
                    return salida;
                }
                catch (Exception ex)
                {
                    string ms = ex.Message;
                    return new List<FormRequest>();
                }
            }
        }
    }
}
