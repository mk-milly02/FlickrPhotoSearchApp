using Caliburn.Micro;
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
            }
        }

        #endregion

        #region Commands

        public async Task SearchAsync()
        {

        }

        #endregion
    }
}
