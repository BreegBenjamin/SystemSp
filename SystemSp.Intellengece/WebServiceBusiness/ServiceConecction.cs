using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using SystemSp.Intellengece.Entities;
using SystemSp.Intellengece.Interfaces;

namespace SystemSp.Intellengece.WebServiceBusiness
{
    public enum Controllers
    {
        Project,
        Users
    }
    public abstract class ServiceConecction
    {
        private readonly HttpClient _httpClient;
        public ServiceConecction(HttpClient client) 
        {
            _httpClient = client;
        }
        private async Task<string> JsonResultService(Controllers baseUri) 
        {
            using (_httpClient) 
            {
                string jsonResult = string.Empty;
                try
                {
                    HttpResponseMessage result = await _httpClient.GetAsync($"api/{baseUri}");
                    jsonResult = (result.IsSuccessStatusCode) ? result.Content.ReadAsStringAsync().Result
                        : result.StatusCode.ToString();
                }
                catch (Exception ex) 
                {
                    jsonResult = ex.Message;
                }
                return jsonResult;
            }
        }
        public async Task<T> GetDataFromService<T>(T entity,Controllers baseUri)
        {
            try
            {
                string json = await JsonResultService(baseUri);
                T result = (T)JsonConvert.DeserializeObject(json, typeof(T));
                return result;
            }
            catch
            {
                return (T)(object)Convert.ChangeType(entity, typeof(T));
            }
        }
    }
}
