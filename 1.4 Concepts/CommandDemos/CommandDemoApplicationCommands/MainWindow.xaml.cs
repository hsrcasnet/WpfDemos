using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommandDemoApplicationCommands
{
    public partial class MainWindow : Window
    {
        private bool isDirty = false;

        public MainWindow()
        {
            this.InitializeComponent();

            // DEMO: CommandBindings can also be created in code-behind
            CommandBinding binding;
            binding = new CommandBinding(ApplicationCommands.New);
            binding.Executed += this.NewCommand;
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Open);
            binding.Executed += this.OpenCommand;
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Save);
            binding.Executed += this.SaveCommand_Executed;
            binding.CanExecute += this.SaveCommand_CanExecute;
            this.CommandBindings.Add(binding);
        }

        private void NewCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"New command triggered from Source={e.Source}");
            this.isDirty = false;
        }

        private void OpenCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"Open command triggered from Source={e.Source}");
            this.isDirty = false;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"Save command triggered from Source={e.Source}");
            this.isDirty = false;
        }

        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            this.isDirty = true;
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.isDirty;
        }

    }
}
