using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UserLookup.Infrastructure.DataProvider
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
            try
            {
                var response = await _client.GetAsync("https://f43qgubfhf.execute-api.ap-southeast-2.amazonaws.com/sampletest");
                string payload = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    payload = await response.Content.ReadAsStringAsync(); // getMockPayLoad(); 
                }

                return JsonConvert.DeserializeObject<T>(payload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string getMockPayLoad()
        {
            return "[{ \"id\": 53, \"first\": \"Bill\", \"last\": \"Bryson\", \"age\":23, \"gender\":\"M\" },{ \"id\": 62, \"first\": \"John\", \"last\": \"Travolta\", \"age\":54, \"gender\":\"M\" },{ \"id\": 41, \"first\": \"Frank\", \"last\": \"Zappa\", \"age\":23, \"gender\":\"T\" },{ \"id\": 31, \"first\": \"Jill\", \"last\": \"Scott\", \"age\":66, \"gender\":\"Y\" },{ \"id\": 31, \"first\": \"Anna\", \"last\": \"Meredith\", \"age\":66, \"gender\":\"Y\" },{ \"id\": 31, \"first\": \"Janet\", \"last\": \"Jackson\", \"age\":66, \"gender\":\"F\" }]";
        }
    }
}
