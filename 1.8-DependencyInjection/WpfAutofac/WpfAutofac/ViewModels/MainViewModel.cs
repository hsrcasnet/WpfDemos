using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfAutofac.Services;

namespace WpfAutofac.ViewModels
{
    public sealed class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IMessageService messageService;
        private readonly ILoadingIndicatorService loadingIndicatorService;

        private RelayCommand showMessageBoxCommand;
        private string firstName;

        public MainViewModel(IMessageService messageService, ILoadingIndicatorService loadingIndicatorService)
        {
            this.messageService = messageService;
            this.loadingIndicatorService = loadingIndicatorService;
        }

        public string ViewTitle
        {
            get { return "Welcome to WPF+Autofac"; }
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                this.RaisePropertyChanged(nameof(this.FirstName));
            }
        }

        public RelayCommand ShowMessageBoxCommand
        {
            get
            {
                return this.showMessageBoxCommand ?? (this.showMessageBoxCommand = new RelayCommand(
                           execute: async () => await this.ShowMessageBox(),
                           canExecute: () => !this.IsLoading));
            }
        }

        private async Task ShowMessageBox()
        {
            try
            {
                this.IsLoading = true;

                this.loadingIndicatorService.ShowLoadingIndicator();
                
                // Call services here...
                await Task.Delay(2000);

                this.loadingIndicatorService.HideLoadingIndicator();

                // Present the result
                this.messageService.Show($"FirstName={this.FirstName}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                this.loadingIndicatorService.HideLoadingIndicator();
                this.IsLoading = false;
            }
        }

        public bool IsLoading { get; private set; }
    }
}