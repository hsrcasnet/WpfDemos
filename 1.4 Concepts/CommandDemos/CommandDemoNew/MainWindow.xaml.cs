using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace CommandDemoNew
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Debug.WriteLine($"NewCommand_CanExecute");
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.WriteLine($"NewCommand_Executed");
            MessageBox.Show($"Command '{((RoutedUICommand)e.Command).Name}' was invoked by {e.OriginalSource.GetType().Name}");
        }
    }
}
