using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Xaml.Behaviors;

namespace BankApp.Behaviors
{
    public class WindowDisappearing : Behavior<Window>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Closing += this.OnWindowClosing;
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            var window = sender as Window;
            window.Closing -= this.OnWindowClosing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, TimeSpan.FromSeconds(2));
            anim.Completed += (s, a) => window.Close();
            window.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Closing -= this.OnWindowClosing;
        }
    }
}
