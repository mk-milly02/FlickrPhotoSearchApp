using System;
using System.Collections.Generic;

namespace PhotoApp.Domain.Models
{
    public class Feed
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public DateTime Modified { get; set; }

        public string Generator { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
