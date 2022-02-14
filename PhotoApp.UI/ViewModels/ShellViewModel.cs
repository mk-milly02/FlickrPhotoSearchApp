using Caliburn.Micro;
using PhotoApp.Domain;
using PhotoApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        #endregion

        #region Commands

        public async Task SearchAsync()
        {
            FlickrFeed = await Flickr.GetFeedAsync(Keyword);
            FeedTitle = FlickrFeed.Title;
        }

        #endregion
    }
}
