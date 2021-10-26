using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfNavigation
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            this.InitializeComponent();

            this.Loaded += delegate
            {
                var navigationWindow = Window.GetWindow(this) as NavigationWindow;
                foreach (var item in navigationWindow.BackStack)
                {
                    Debug.WriteLine(item);
                }
            };
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }
    }
}