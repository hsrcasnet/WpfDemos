using System;

namespace BankApp.Commands
{
    public class RelayCommand : BaseCommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
            {
                return;
            }

            this.execute?.Invoke(parameter);
        }
    }
}
