using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserLookup.Infrastructure.Configurations;

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
                var response = await _client.GetAsync(Constants.Uri);
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
    }
}
