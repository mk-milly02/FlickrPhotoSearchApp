using System.Threading.Tasks;
using Xunit;

namespace PhotoApp.Domain.Tests
{
    public class TwitterTests
    {
        [Fact]
        public async Task ReturnTrue_GetResultCountAsync()
        {
            int expected = 60;

            var response = await Twitter.GetTweetsAsync("nature");

            int actual = response.Meta.Result_Count;

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public async Task ShouldPass_GetNumberOfTweetsAsync()
        {
            int expected = 60;

            var response = await Twitter.GetTweetsAsync("nature");

            int actual = response.data.Count;

            Assert.Equal(expected, actual);
        }
    }
}
