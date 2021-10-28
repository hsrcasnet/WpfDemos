using System.Windows;
using System.Windows.Input;

namespace CommandDemoOpenClose
{
    public partial class MainWindow : Window
    {
        private bool isFileOpen = false;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void CanExecuteCloseCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            // Call a method to determine if there is a file open.
            // If there is a file open, then set CanExecute to true.
            e.CanExecute = this.isFileOpen;
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // Calls a method to close the file and release resources.
            this.CloseFile();
        }

        private void CanExecuteOpenCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !this.isFileOpen;
        }

        private void OpenCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.OpenFile();
        }

        private void OpenFile()
        {
            this.isFileOpen = true;
        }

        private void CloseFile()
        {
            this.isFileOpen = false;
        }
    }
}