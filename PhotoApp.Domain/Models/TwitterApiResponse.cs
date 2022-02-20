using Newtonsoft.Json;
using System.Collections.Generic;

namespace PhotoApp.Domain.Models
{
    public class TwitterApiResponse
    {
        [JsonProperty("data")]
        public List<Tweet> Tweets { get; set; }

        public Includes Includes { get; set; }

        public Meta Meta { get; set; }
    }
}
