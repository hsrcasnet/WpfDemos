using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommandDemo3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void SaveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            MessageBox.Show("About to save: " + text);
            this.isDirty[sender] = false;
        }

        private readonly Dictionary<object, bool> isDirty = new Dictionary<object, bool>();
        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            this.isDirty[sender] = true;
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.isDirty.ContainsKey(sender) && this.isDirty[sender] == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }

}

