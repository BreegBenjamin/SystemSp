using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SystemSp.Intellengece.WebServiceBusiness
{
    public abstract class ServiceConecction
    {
        private readonly HttpClient _httpClient;
        public ServiceConecction(HttpClient client) 
        {
            _httpClient = client;
        }
        private async Task<string> _jsonResultService(string uri) 
        {
            string jsonResult = string.Empty;
            try
            {
                HttpResponseMessage result = await _httpClient.GetAsync($"api/{uri}");
                jsonResult = (result.IsSuccessStatusCode) ? result.Content.ReadAsStringAsync().Result
                    : result.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                jsonResult = ex.Message;
            }
            return jsonResult;
        }
        private async Task<string> _jsonResultService<T>(string uri, T entity)
        {
            using (_httpClient)
            {
                string jsonResult = string.Empty;
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(entity), 
                        Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await _httpClient.PostAsync($"api/{uri}", stringContent);
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
        private async Task<bool> _checkEmail(string email)
        {
            string json = await _jsonResultService("Person/ValidateEmail", email);
            try
            {
                bool result = (bool)JsonConvert.DeserializeObject(json, typeof(bool));
                return result;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> CheckEmail(string email) => await _checkEmail(email);
        public async Task<T> GetDataFromService<T>(T entity, string baseUri)
        {
            try
            {
                string json = await _jsonResultService(baseUri);
                T result = (T)JsonConvert.DeserializeObject(json, typeof(T));
                return result;
            }
            catch
            {
                return (T)Convert.ChangeType(entity, typeof(T));
            }
        }
        public async Task<bool> SendDataToService<T>(T entity, string baseUri)
        {
            try
            {
                string json = await _jsonResultService<T>(baseUri, entity);
                bool result = (bool)JsonConvert.DeserializeObject(json);
                return result;
            }
            catch(Exception ex)
            {
                string ms = ex.Message;
                return false;
            }
        }
        public async Task<L> SendDataToServiceParam<T,L>(T entity, string baseUri)
        {
            try
            {
                string json = await _jsonResultService<T>(baseUri, entity);
                L result = (L)JsonConvert.DeserializeObject(json, typeof(L));
                return result;
            }
            catch
            {
                return (L)Convert.ChangeType(entity, typeof(L));
            }
        }
    }
}
