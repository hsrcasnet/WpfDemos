using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

namespace CommandDemoApplicationCommands
{
    public partial class MainWindow : Window
    {
        private const string TextFilesFilter = "Text files (*.txt)|*.txt";
        private bool isDirty = false;
        private string currentFileName;

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
            Debug.WriteLine($"New command triggered from Source={e.Source.GetType().Name}");
            this.currentFileName = null;
            this.Notepad.Text = string.Empty;
            this.isDirty = false;
        }

        private void OpenCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.WriteLine($"Open command triggered from Source={e.Source.GetType().Name}");

            // Demo: Simple use case of OpenFileDialog
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = TextFilesFilter;
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                this.currentFileName = openFileDialog.FileName;
                this.Notepad.Text = File.ReadAllText(openFileDialog.FileName);
                this.isDirty = false;
            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.WriteLine($"Save command triggered from Source={e.Source.GetType().Name}");

            if (currentFileName == null)
            {
                // Demo: Simple use case of SaveFileDialog
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = TextFilesFilter;
                var result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    this.currentFileName = saveFileDialog.FileName;
                    File.WriteAllText(saveFileDialog.FileName, this.Notepad.Text);
                    this.isDirty = false;
                }
            }
            else
            {
                File.WriteAllText(this.currentFileName, this.Notepad.Text);
                this.isDirty = false;
            }
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
