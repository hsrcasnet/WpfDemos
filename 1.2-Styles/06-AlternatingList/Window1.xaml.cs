using System.Windows;

namespace _06_AlternatingList
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.listBoxEntries.Items.Add("New Entry");
        }
    }
}