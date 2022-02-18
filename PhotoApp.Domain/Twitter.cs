using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PhotoApp.Domain.Models;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoApp.Domain
{
    public class Twitter
    {
        private static string GetBearerToken()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Appsettings.json").Build();

            return configuration.GetSection("bearer_token").Value;
        }

        public static async Task<TwitterApiResponse> GetTweetsAsync(string search)
        {
            string uri = $"https://api.twitter.com/2/tweets/search/recent?max_results=60&expansions=author_id&user.fields=created_at,description&query={search}";
            
            HttpClient client = new();

            client.DefaultRequestHeaders.Add("Authorization", GetBearerToken());

            var response = await client.GetStringAsync(uri);

            TwitterApiResponse responseBody = JsonConvert.DeserializeObject<TwitterApiResponse>(response);

            return responseBody;
        }
    }
}
