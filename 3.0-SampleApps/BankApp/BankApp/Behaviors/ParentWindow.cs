using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace BankApp.Behaviors
{
    public class ParentWindow : Behavior<Window>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += this.AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is Window mainWindow)
            {
                if (sender is Window childWindow)
                {
                    childWindow.Top = (mainWindow.Top + mainWindow.Height - 10) - childWindow.Height;
                    childWindow.Left = (mainWindow.Left + mainWindow.Width - 10) - childWindow.Width;
                }
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= this.AssociatedObject_Loaded;
        }
    }
}
