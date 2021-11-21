using System.Windows;

namespace BankApp.Commands
{
    public class CloseWindowCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => parameter is Window;

        public override void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
            {
                return;
            }

            var window = (Window)parameter;
            window.Close();
        }
    }
}
