using System.Text.Json.Serialization;

namespace PhotoApp.Domain
{
    public class Meta
    {
        [JsonPropertyName("newest_id")]
        public string NewestId { get; set; }

        [JsonPropertyName("oldest_id")]
        public string OldestId { get; set; }

        [JsonPropertyName("next_token")]
        public string NextToken { get; set; }

        [JsonPropertyName("result_count")]
        public int Result_Count { get; set; }
    }
}
