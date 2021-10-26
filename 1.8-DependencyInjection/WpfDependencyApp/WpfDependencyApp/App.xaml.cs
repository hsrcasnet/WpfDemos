using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WpfDependencyApp.Services;
using WpfDependencyApp.Views;

namespace WpfDependencyApp
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();

            // Register dependencies
            serviceCollection.AddLogging(configure => configure.AddDebug());

            var useMockServices = true;
            if (useMockServices)
            {
                serviceCollection.AddSingleton<IEmployeeRepository, EmployeeRepositoryStub>();
            }
            else
            {
                serviceCollection.AddSingleton<IEmployeeRepository, EmployeeRepositoryEF>();
            }

            serviceCollection.AddSingleton<MainWindow>();

            // Create DI container
            this.serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = this.serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
