using System.Net.Http;
using System.Threading.Tasks;

namespace Infraestructure.WebClient
{
    public class WebClient
    {
        protected HttpClient GetClient()
        {
            return new HttpClient();
        }

        protected async Task<string> ExecutePost(string url, HttpContent content)
        {
            using var httpClient = GetClient();
            using var response = await httpClient.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<string> ExecuteGet(string url)
        {
            using var httpClient = GetClient();
            using var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
