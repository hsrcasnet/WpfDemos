using System.Windows;
using System.Windows.Input;

namespace CommandDemo0
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void CanExecuteSave(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecutedSave(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Saved!");
        }
    }
}
