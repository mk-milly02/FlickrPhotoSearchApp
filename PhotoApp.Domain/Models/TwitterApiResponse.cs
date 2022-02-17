namespace PhotoApp.Domain.Models
{
    public class TwitterApiResponse
    {
        public Tweet[] Tweets { get; set; }

        public Includes Includes { get; set; }

        public Meta Meta { get; set; }
    }
}
