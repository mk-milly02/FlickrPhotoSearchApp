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

            string responseBody = response[response.IndexOf("{")..];

            string feedText = responseBody.Remove(responseBody.LastIndexOf(")"));

            Feed feed = JsonConvert.DeserializeObject<Feed>(feedText);

            return feed;
        }
    }
}
