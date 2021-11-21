using System.Windows;

namespace BankApp.Commands
{
    public class CloseDialogCommand : BaseCommand
    {
        public bool? DialogResult { get; set; }

        public override bool CanExecute(object parameter) => parameter is Window;

        public override void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
            {
                return;
            }

            var window = (Window)parameter;
            window.DialogResult = this.DialogResult;
            window.Close();
        }
    }
}
