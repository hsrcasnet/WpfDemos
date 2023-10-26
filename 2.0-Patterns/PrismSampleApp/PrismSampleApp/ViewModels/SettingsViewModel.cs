using Prism.Commands;
using Prism.Regions;
using PrismSampleApp.Views;

namespace PrismSampleApp.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly IRegionManager regionManager;

        public SettingsViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.Title = "Settings";
        }

        public DelegateCommand NavigateToChildCommand => new DelegateCommand(() =>
        {
            var navigationParameters = new NavigationParameters
            {
                { "key1", "Some text" },
                { "key2", 999 }
            };

            this.regionManager.RequestNavigate(
                RegionNames.ContentRegion,
                nameof(SubSettingsView),
                navigationParameters);
        });

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
        }
    }
}
