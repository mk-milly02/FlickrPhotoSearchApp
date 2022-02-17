using Caliburn.Micro;
using Microsoft.Extensions.Configuration;
using PhotoApp.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        public IConfiguration AddConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            return configuration;
        }

        protected override void Configure()
        {
            container.Instance(container);

            container.RegisterInstance(typeof(IConfiguration), "IConfiguration", AddConfiguration());
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }
    }
}
