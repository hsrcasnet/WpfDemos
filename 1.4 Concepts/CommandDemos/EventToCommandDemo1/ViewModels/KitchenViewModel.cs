using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EventToCommandDemo1.ViewModels
{
    public class KitchenViewModel : INotifyPropertyChanged
    {
        private bool isCooking;

        public ICommand CookDinnerCommand { get; private set; }

        public KitchenViewModel()
        {
            this.CookDinnerCommand = new DelegateCommand<string>(
                execute: msg => this.CookDinner(msg),
                canExecute: () => !this.IsCooking);
        }

        public bool IsCooking
        {
            get => this.isCooking;
            private set
            {
                this.isCooking = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsCooking)));
            }
        }

        private async void CookDinner(string message)
        {
            try
            {
                this.IsCooking = true;

                // Call cooking services here...
                await Task.Delay(2000);

                MessageBox.Show($"Finished cooking: {message} is ready!");
            }
            catch (Exception)
            {

            }
            finally
            {
                this.IsCooking = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}