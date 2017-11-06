using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Server.RestClients
{
    public class RestClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static string Get(string url)
        {
            return HttpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        public static string Post(string url, object data)
        {
            var content = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            return HttpClient.PostAsync(url, byteContent).Result.Content.ReadAsStringAsync().Result;
        }

        public static void Delete<T>(string url, T data)
        {
            var content = JsonConvert.SerializeObject(data);

            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);

            HttpClient.PostAsync(url, byteContent);
        }
    }
}