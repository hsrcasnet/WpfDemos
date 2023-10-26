using Prism.Commands;
using Prism.Regions;
using PrismSampleApp.Views;

namespace PrismSampleApp.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        private const int Collapsed = 40;
        private const int Expanded = 200;

        private readonly IRegionNavigationJournal journal;
        private readonly IRegionManager regionManager;
        private int flyoutWidth;

        public SidebarViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.Title = "Navigation";
            this.FlyoutWidth = Expanded;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }

        public DelegateCommand DashboardCommand => new(() =>
        {
            //// _journal.Clear();
            this.regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(DashboardView));
        });

        public DelegateCommand FlyoutMenuCommand => new(() =>
        {
            var isExpanded = this.FlyoutWidth == Expanded;
            this.FlyoutWidth = isExpanded ? Collapsed : Expanded;
        });

        public DelegateCommand SettingsCommand => new(() =>
        {
            this.regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(SettingsView));
        });

        public int FlyoutWidth
        {
            get => this.flyoutWidth;
            private set => this.SetProperty(ref this.flyoutWidth, value);
        }
    }
}
