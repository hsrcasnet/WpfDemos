using System.Windows;
using System.Windows.Controls;

namespace XAMLIntro0Code
{
    public partial class App : Application
    {
        public App()
        {
            var button = new Button { Content = "Click Me!" };

            var stackPanel = new StackPanel();
            stackPanel.Children.Add(button);

            var window = new Window
            {
                Title = "Code Demo",
                Height = 350,
                Width = 525,
                Content = stackPanel
            };
            window.Show();
        }
    }
}