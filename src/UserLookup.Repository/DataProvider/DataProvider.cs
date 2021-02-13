using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserLookup.Repository.DataProvider
{
    public interface IDataProvider : IDisposable
    {
        Task<T> QueryData<T>();
    }

    public class HttpDataProvider : IDataProvider
    {
        private readonly HttpClient _client;

        public HttpDataProvider()
        {
            _client = new HttpClient();
        }

        public HttpDataProvider(HttpClient client) => _client = client;

        public void Dispose()
        {
            // Do nothing for HTTP
        }

        public async Task<T> QueryData<T>()
        {
            var response = await _client.GetAsync("https://f43qgubfhf.execute-api.ap-southeast-2.amazonaws.com/sampletest");
            string payload = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                payload = await response.Content.ReadAsStringAsync();
            }

            return JsonSerializer.Deserialize<T>(payload);
        }
    }
}
