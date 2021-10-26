using System;
using System.Windows;
using System.Windows.Controls;

namespace RoutedClickEventNoXAML
{

    public class Window1 : Window
    {
        StackPanel panel = new StackPanel();
        SimpleButton btnYes = new SimpleButton();
        SimpleButton btnNo = new SimpleButton();
        SimpleButton btnCancel = new SimpleButton();

        public Window1()
        {
            this.Title = "Window1";
            this.Height = 300;
            this.Width = 300;
            btnYes.Content = "Yes";
            btnYes.Name = "btnYes";
            btnNo.Content = "No";
            btnNo.Name = "btnNo";
            btnCancel.Content = "Cancel";
            btnCancel.Name = "Cancel";
            panel.Children.Add(btnYes);
            panel.Children.Add(btnNo);
            panel.Children.Add(btnCancel);
            panel.AddHandler(SimpleButton.ClickEvent, new RoutedEventHandler(SimpleButton_Click));
            btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
            this.Content = panel;
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            SimpleButton sb = e.Source as SimpleButton;
            switch (sb.Name)
            {
                case "btnYes":
                    MessageBox.Show("Yes");
                    break;
                case "btnNo":
                    MessageBox.Show("No no");
                    break;
                case "btnCancel":
                    MessageBox.Show("Cancel");
                    break;
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            SimpleButton sb = e.Source as SimpleButton;
            if (sb != null)
            {
                MessageBox.Show("CancelButton: Cancel");
                // e.Handled = true;
            }

        }
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new Window1());

        }

    }
}

