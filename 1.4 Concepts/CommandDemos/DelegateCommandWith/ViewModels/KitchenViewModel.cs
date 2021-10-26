using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DelegateCommandWith.Model;
using DelegateCommandWith.Services;

namespace DelegateCommandWith.ViewModels
{
    public class KitchenViewModel
    {
        private readonly IKitchenService kitchenService;
        private readonly IDialogService dialogService;

        public ICommand CookDinnerCommand { get; private set; }

        public KitchenViewModel(IKitchenService kitchenService, IDialogService dialogService)
        {
            this.kitchenService = kitchenService;
            this.dialogService = dialogService;

            this.CookDinnerCommand = new DelegateCommand<string>(
                execute: async msg => await this.CookDinner(msg),
                canExecute: () => !this.IsCooking);
        }

        public bool IsCooking { get; private set; }

        private async Task CookDinner(string message)
        {
            try
            {
                this.IsCooking = true;

                var mealDto = await this.kitchenService.PrepareMeal(numberOfPersons: 3);

                this.dialogService.ShowMessageBox($"Finished cooking: {mealDto.Name} is ready!");
            }
            catch (Exception e)
            {
                this.dialogService.ShowMessageBox($"Cooking failed: {e}");
            }
            finally
            {
                this.IsCooking = false;
            }
        }
    }
}