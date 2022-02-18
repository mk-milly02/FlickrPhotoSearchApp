using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PhotoApp.Domain.Models
{
    public class TwitterApiResponse
    {
        public List<Tweet> data { get; set; }

        public Includes Includes { get; set; }

        public Meta Meta { get; set; }
    }
}
