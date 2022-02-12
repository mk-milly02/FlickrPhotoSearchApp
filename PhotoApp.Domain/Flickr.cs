using Newtonsoft.Json;
using PhotoApp.Domain.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoApp.Domain
{
    public static class Flickr
    {
        public static async Task<Feed> GetFeedAsync(string search)
        {
            string uri = $"https://www.flickr.com/services/feeds/photos_public.gne?format=json&tags={search}";

            HttpClient client = new();

            var response = await client.GetStringAsync(uri);

            Feed feed = JsonConvert.DeserializeObject<Feed>(response);

            return feed;
        }
    }
}
