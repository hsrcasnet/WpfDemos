using System.Windows;
using System.Windows.Controls;
using BankApp.Extensions;
using Microsoft.Xaml.Behaviors;

namespace BankApp.Behaviors
{

    public class CloseWindowItemMenu : Behavior<MenuItem>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Click += this.OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e) => (this.AssociatedObject.FindLogicalRoot() as Window)?.Close();

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= this.OnButtonClick;
        }
    }
}
