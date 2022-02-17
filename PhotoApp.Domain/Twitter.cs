using PhotoApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.Domain
{
    public class Twitter
    {
        public async Task<TwitterApiResponse> GetTweetsAsync(string search)
        {
            string uri = $"https://api.twitter.com/2/tweets/search/recent?max_results=60&expansions=author_id&user.fields=created_at,description&query={search}";
            
            HttpClient client = new();

            var response = await client.GetAsync(uri);

            response.Headers.Add("Authorization", "application/json");


        }
    }
}
