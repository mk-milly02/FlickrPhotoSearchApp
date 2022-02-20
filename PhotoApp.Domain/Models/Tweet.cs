using Newtonsoft.Json;

namespace PhotoApp.Domain
{
    public class Tweet
    {
        [JsonProperty("author_id")]
        public string AuthorId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

    }

    public class Includes
    {
        public User[] Users { get; set; }
    }
}
