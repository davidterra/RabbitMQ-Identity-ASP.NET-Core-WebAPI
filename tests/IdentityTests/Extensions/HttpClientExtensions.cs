using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdentityTests
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsync(this HttpClient client, string requestUri, object obj)
            => client.PostAsync(requestUri, GetStringContent(obj));

        public static Task<HttpResponseMessage> PostAsync(this HttpClient client, string requestUri, string payload)
            => client.PostAsync(requestUri, GetStringContent(payload));

        private static StringContent GetStringContent(object obj)
            => new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

        private static StringContent GetStringContent(string playload)
            => new StringContent(playload, Encoding.UTF8, "application/json");
    }
}
