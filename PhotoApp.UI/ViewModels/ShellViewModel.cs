using Caliburn.Micro;
using PhotoApp.Domain;
using PhotoApp.Domain.Models;
using PhotoApp.UI.CustomControls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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

        #endregion

        #region Commands

        public async Task SearchAsync()
        {
            await DisplayPhotosAsync();
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

        #endregion
    }
}
