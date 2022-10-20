using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfAutofac.Services;

namespace WpfAutofac.ViewModels
{
    public sealed class MainViewModel : ObservableObject, IMainViewModel
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

        public string ViewTitle => "Welcome to WPF+Autofac";

        public string FirstName
        {
            get => this.firstName;
            set => this.SetProperty(ref this.firstName, value);
        }

        public RelayCommand ShowMessageBoxCommand => this.showMessageBoxCommand ??= new RelayCommand(
                           execute: async () => await this.ShowMessageBox(),
                           canExecute: () => !this.IsLoading);

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
            catch (Exception)
            {
                this.messageService.Show($"Something went wrong. Try again. [Error Code 1002]");
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