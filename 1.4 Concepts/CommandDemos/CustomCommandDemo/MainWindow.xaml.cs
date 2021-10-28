using System.Windows;
using System.Windows.Input;

namespace CustomCommandDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void RequeryCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"RequeryCommand executed by Source={e.Source.GetType().Name}");
        }
    }
}