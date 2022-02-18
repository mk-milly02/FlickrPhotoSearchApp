using System.Text.Json.Serialization;

namespace PhotoApp.Domain
{
    public class Tweet
    {
        [JsonPropertyName("author_id")]
        public string AuthorId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

    }

    public class Includes
    {
        public User[] Users { get; set; }
    }
}
