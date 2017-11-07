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
            var str = await task.Result.Content.ReadAsStringAsync();
            return str;
        }

        public async Task<string> Post(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var task = _httpClient.PostAsync(url, content);
            var str = await task.Result.Content.ReadAsStringAsync();
            return str;
        }

        public async Task<string> Put(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var task = _httpClient.PutAsync(url, content);
            var str = await task.Result.Content.ReadAsStringAsync();
            return str;
        }

        public async Task<string> Delete(string url)
        {
            var task = _httpClient.DeleteAsync(url);
            var str = await task.Result.Content.ReadAsStringAsync();
            return str;
        }
    }
}