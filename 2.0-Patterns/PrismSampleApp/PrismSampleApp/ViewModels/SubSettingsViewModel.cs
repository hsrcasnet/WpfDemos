using Prism.Commands;
using Prism.Regions;
using PrismSampleApp.Views;

namespace PrismSampleApp.ViewModels
{
    public class SubSettingsViewModel : ViewModelBase
    {
        private readonly IRegionManager regionManager;

        private IRegionNavigationJournal journal;
        private string messageText = string.Empty;
        private string messageNumber = string.Empty;

        public SubSettingsViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            this.Title = "Settings - SubView";
        }

        public DelegateCommand NavigateBackCommand => new DelegateCommand(() =>
        {
            // Go back to the previous calling page, otherwise, Dashboard.
            if (this.journal != null && this.journal.CanGoBack)
            {
                this.journal.GoBack();
            }
            else
            {
                this.regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(DashboardView));
            }
        });

        public string MessageText
        {
            get => this.messageText;
            set => this.SetProperty(ref this.messageText, value);
        }

        public string MessageNumber
        {
            get => this.messageNumber;
            set => this.SetProperty(ref this.messageNumber, value);
        }

        /// <summary>Navigation completed successfully.</summary>
        /// <param name="navigationContext">Navigation context.</param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Used to "Go Back" to parent
            this.journal = navigationContext.NavigationService.Journal;

            // Display our parameters
            this.MessageText = navigationContext.Parameters["key1"].ToString();
            this.MessageNumber = navigationContext.Parameters["key2"].ToString();
        }

        public override bool OnNavigatingTo(NavigationContext navigationContext)
        {
            // Navigation permission sample:
            // Don't allow navigation if our keys are missing
            return navigationContext.Parameters.ContainsKey("key1") &&
                   navigationContext.Parameters.ContainsKey("key2");
        }
    }
}
