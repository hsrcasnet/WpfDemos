using System.Collections.ObjectModel;
using Prism.Commands;
using PrismSampleApp.Services;

namespace PrismSampleApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly IMessageService messageService;

        private int counter = 0;
        private int listItemSelected = -1;
        private ObservableCollection<string> listItems = new();

        public DashboardViewModel(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public DelegateCommand AddItemCommand => new(() =>
        {
            this.counter++;
            this.ListItems.Add($"Item Number: {this.counter}");
        });

        public DelegateCommand ClearItemsCommand => new(this.ListItems.Clear);

        public DelegateCommand ShowMessageBoxCommand => new(() =>
        {
            this.messageService.Show($"Selected item: \"{this.ListItemText}\"");
        });

        public int ListItemSelected
        {
            get => this.listItemSelected;
            set
            {
                if (this.SetProperty(ref this.listItemSelected, value))
                {
                    this.RaisePropertyChanged(nameof(this.ListItemText));
                }
            }
        }

        public string ListItemText => this.ListItemSelected == -1 ? "-" : this.ListItems[this.ListItemSelected];

        public ObservableCollection<string> ListItems
        {
            get => this.listItems;
            set => this.SetProperty(ref this.listItems, value);
        }
    }
}
