using System.Threading.Tasks;
using Xunit;

namespace PhotoApp.Domain.Tests
{
    public class FlickrTests
    {
        [Fact]
        public async Task ShouldPassValid_GetFeedAsync()
        {
            string link = "https://www.flickr.com/photos/tags/nature/";

            var output = await Flickr.GetFeedAsync("nature");

            Assert.Equal(link, output.Link);
        }
    }
}
