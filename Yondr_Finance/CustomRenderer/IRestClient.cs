using System.Threading.Tasks;

namespace Yondr_Finance.CustomRenderer
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string url, bool useAuthToken = false);
        Task<T> PostAsync<T>(string url, object payload, bool useAuthToken = false);
        Task<T> PutAsync<T>(string url, object payload, bool useAuthToken = false);
        Task<T> DeleteAsync<T>(string url, bool useAuthToken = false);
    }
}