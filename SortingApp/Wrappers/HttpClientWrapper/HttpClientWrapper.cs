using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SortingApp.Wrappers.HttpClientWrapper
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private const string JsonHeader = "application/json";
        private string _apiName;
        private HttpClient _httpClient;

        public void Initialize(string baseUrl, string apiName)
        {
            var httpClientHandler = new HttpClientHandler
            {
                UseDefaultCredentials = true,
                ClientCertificateOptions = ClientCertificateOption.Automatic
            };

            _httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(baseUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonHeader));
            _apiName = apiName;
        }

        public async Task<T> PostAsJsonAsync<T>(string apiMethod, object value)
        {
            return await ReadResponse<T>(HandleRequest(() => _httpClient.PostAsJsonAsync(apiMethod, value)));
        }


        private async Task<HttpResponseMessage> HandleRequest(Func<Task<HttpResponseMessage>> apiMethod)
        {
            return await apiMethod();
        }

        private async Task<T> ReadResponse<T>(Task<HttpResponseMessage> responseAsync)
        {
            var response = await responseAsync;

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            throw new InvalidOperationException($"API Server ({_apiName}) returned HTTP error Uri : {response.RequestMessage.RequestUri} | {(int)response.StatusCode} : {response.ReasonPhrase}. ");
        }
    }
}