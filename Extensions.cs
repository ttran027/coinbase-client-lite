using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoinbaseClientLite
{
    public static class Extensions
    {
        public async static Task<T> GetObject<T>(this HttpResponseMessage m)
        {
            var content = await m.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new() { PropertyNameCaseInsensitive = true });
        }
    }
}
