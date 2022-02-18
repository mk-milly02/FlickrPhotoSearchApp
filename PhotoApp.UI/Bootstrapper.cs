using Caliburn.Micro;
using PhotoApp.UI.ViewModels;
using System.Windows;

namespace PhotoApp.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer container = new();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
