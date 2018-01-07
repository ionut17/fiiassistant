using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.RestClients
{
    public class RestClient
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> Get(string url)
        {
            var task = _httpClient.GetAsync(url);
            var result = task.Result;
            if (!result.IsSuccessStatusCode)
                return null;
            var resultString = await result.Content.ReadAsStringAsync();
            return resultString;
        }

        public async Task<string> Post(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync(url, content);
            var resultString = await task.Result.Content.ReadAsStringAsync();
            return resultString;
        }

        public async Task<string> Put(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var task = _httpClient.PutAsync(url, content);
            var resultString = await task.Result.Content.ReadAsStringAsync();
            return resultString;
        }

        public async Task<string> Delete(string url)
        {
            var task = _httpClient.DeleteAsync(url);
            var resultString = await task.Result.Content.ReadAsStringAsync();
            return resultString;
        }
    }
}