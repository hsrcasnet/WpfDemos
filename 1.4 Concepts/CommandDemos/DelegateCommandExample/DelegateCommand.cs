using System;
using System.Windows.Input;

namespace DelegateCommandExample
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> executeAction;
        private readonly Func<bool> canExecute;

        public DelegateCommand(Action<T> executeAction)
            : this(executeAction, () => true)
        {
            this.executeAction = executeAction;
        }

        public DelegateCommand(Action<T> executeAction, Func<bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        // ICommand
        public void Execute(object parameter)
        {
            var param = default(T);
            if (parameter is T variable)
            {
                param = variable;
            }

            this.executeAction(param);
        }

        // ICommand
        public bool CanExecute(object parameter)
        {
            return this.canExecute();
        }

        // Forward CanExecuteChanged to CommandManager.RequerySuggested event
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}