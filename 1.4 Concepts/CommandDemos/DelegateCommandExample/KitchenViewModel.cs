using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RoutedCommandExample
{
    public class KitchenViewModel
    {
        public ICommand CookDinnerCommand { get; private set; }

        public KitchenViewModel()
        {
            this.CookDinnerCommand = new DelegateCommand<string>(
                execute: async p => await this.CookDinner(p),
                canExecute: () => !this.IsCooking);
        }

        public bool IsCooking { get; private set; }

        private async Task CookDinner(string parameter)
        {
            try
            {
                this.IsCooking = true;

                // Call cooking services here...
                await Task.Delay(2000);

                MessageBox.Show($"Finished cooking: {parameter} is ready!");
            }
            catch (Exception e)
            {
                // Handle exception here
            }
            finally
            {
                this.IsCooking = false;
            }
        }
    }
}