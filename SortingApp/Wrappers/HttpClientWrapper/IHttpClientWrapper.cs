using System.Threading.Tasks;

namespace SortingApp.Wrappers.HttpClientWrapper
{
    public interface IHttpClientWrapper
    {
        void Initialize(string baseUrl, string apiName);
        Task<T> PostAsJsonAsync<T>(string apiMethod, object value);

    }
}