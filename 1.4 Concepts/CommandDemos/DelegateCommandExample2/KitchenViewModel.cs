using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DelegateCommandExample2
{
    public class KitchenViewModel : INotifyPropertyChanged
    {
        private ICommand cookDinnerCommand;
        private bool isCooking;
        private string message;

        public KitchenViewModel()
        {
        }

        public ICommand CookDinnerCommand
        {
            get
            {
                return this.cookDinnerCommand ?? (this.cookDinnerCommand = new DelegateCommand<string>(
                    execute: async (msg) => await this.CookDinner(msg),
                    canExecute: () => !this.IsCooking));
            }
        }

        public bool IsCooking
        {
            get => this.isCooking;
            private set
            {
                this.isCooking = value;
                this.OnPropertyChanged(nameof(this.IsCooking));
            }
        }

        public string Message
        {
            get => this.message;
            private set
            {
                this.message = value;
                this.OnPropertyChanged(nameof(this.Message));
            }
        }

        private async Task CookDinner(string message)
        {
            try
            {
                this.IsCooking = true;

                this.Message += $"{DateTime.Now:G} -> Cooking started... {Environment.NewLine}";

                // Call cooking services here...
                await Task.Delay(2000);

                this.Message += $"{DateTime.Now:G} -> Finished cooking: {message} is ready! {Environment.NewLine}";
            }
            catch (Exception e)
            {

            }
            finally
            {
                this.IsCooking = false;
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}