using Caliburn.Micro;
using PhotoApp.Domain;
using PhotoApp.Domain.Models;
using PhotoApp.UI.CustomControls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;

namespace PhotoApp.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel() { }

        #region Properties

        private string keyword;

        public string Keyword
        {
            get { return keyword; }
            set 
            {
                keyword = value;
                NotifyOfPropertyChange(() => Keyword);
                NotifyOfPropertyChange(() => CanSearchAsync);
            }
        }

        public Feed FlickrFeed { get; set; }

        private string title;

        public string FeedTitle
        {
            get { return title; }
            set 
            {
                title = value;
                NotifyOfPropertyChange(() => FeedTitle);
            }
        }

        public bool CanSearchAsync
        {
            get 
            {
                bool output = true;

                if (string.IsNullOrWhiteSpace(Keyword))
                {
                    output = false; 
                }

                return output;
            }
        }

        private ObservableCollection<PhotoElement> photos;

        public ObservableCollection<PhotoElement> Photos
        {
            get { return photos; }
            set 
            {
                photos = value;
                NotifyOfPropertyChange(() => Photos);
            }
        }

        public TwitterApiResponse Response { get; set; }

        private ObservableCollection<TweetElement> tweets;

        public ObservableCollection<TweetElement> Tweets
        {
            get { return tweets; }
            set 
            {
                tweets = value;
                NotifyOfPropertyChange(() => Tweets); 
            }
        }

        #endregion

        #region Commands

        public async Task SearchAsync()
        {
            await DisplayPhotosAsync();

            await DisplayTweetsAsync();
        }

        private async Task DisplayPhotosAsync()
        {
            FlickrFeed = await Flickr.GetFeedAsync(Keyword);

            FeedTitle = FlickrFeed.Title;

            Photos = new();

            foreach (var item in FlickrFeed.Photos)
            {
                PhotoElement photo = new(item);
                Photos.Add(photo);
            }
        }

        private User GetUser(string authorId)
        {
            return Response.Includes.Users.Where(user => user.Id.Equals(authorId)).FirstOrDefault();
        }

        private async Task DisplayTweetsAsync()
        {
            Response = await Twitter.GetTweetsAsync(Keyword);

            Tweets = new();

            foreach (var item in Response.Tweets)
            {
                TweetElement tweet = new(item, GetUser(item.AuthorId));
                Tweets.Add(tweet);
            }
        }

        public async void HandleInput(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await SearchAsync();
            }
        }

        #endregion
    }
}
