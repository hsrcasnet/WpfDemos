using System.Windows;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismSampleApp.Services;
using PrismSampleApp.ViewModels;
using PrismSampleApp.Views;

namespace PrismSampleApp
{
    /// <summary>
    /// Prism WPF sample app.
    /// There are a lot more samples to be found here:
    /// https://github.com/PrismLibrary/Prism-Samples-Wpf/tree/master
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register services
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();

            // Register views and viewmodels
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<SubSettingsView, SubSettingsViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // Register optional modules in the catalog
            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override Window CreateShell()
        {
            // User interface entry point, called after RegisterTypes and ConfigureModuleCatalog.
            var mainWindow = this.Container.Resolve<MainWindow>();
            return mainWindow;
        }

        protected override void OnInitialized()
        {
            // Register Views to the Region it will appear in. Don't register them in the ViewModel.
            var regionManager = this.Container.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(DashboardView));
            regionManager.RegisterViewWithRegion(RegionNames.SidebarRegion, typeof(SidebarView));

            base.OnInitialized();
        }
    }
}