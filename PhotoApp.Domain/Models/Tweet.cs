using System;

namespace PhotoApp.Domain
{
    public class Tweet
    {
        public string AuthorId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Id { get; set; }

        public string Text { get; set; }

    }

    public class Includes
    {
        public User[] Users { get; set; }
    }
}
