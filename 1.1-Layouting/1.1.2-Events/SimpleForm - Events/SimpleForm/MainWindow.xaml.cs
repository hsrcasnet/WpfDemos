using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SimpleForm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Full Name: {this.FullName.Text}");
            sb.AppendLine($"Sex: {((bool)this.Male.IsChecked ? "Male" : "Female")}");
            sb.AppendLine($"Computer: {this.GetComputerString()}");
            sb.AppendLine($"Your job: {this.Job.SelectedItem ?? "<not selected>"}");
            sb.AppendLine($"Delivery Date: {this.DeliveryDate.SelectedDate.ToString()}");
            MessageBox.Show(sb.ToString());
        }

        private string GetComputerString()
        {
            if ((bool)this.Desktop.IsChecked)
            {
                return "Desktop";
            }

            if ((bool)this.Laptop.IsChecked)
            {
                return "Laptop";
            }

            if ((bool)this.Tablet.IsChecked)
            {
                return "Tablet";
            }

            return "<not selected>";
        }

        private void Job_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];
            MessageBox.Show(selectedItem.ToString());
        }
    }
}