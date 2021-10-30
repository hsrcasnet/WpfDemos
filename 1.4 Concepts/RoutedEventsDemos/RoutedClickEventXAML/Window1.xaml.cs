using System;
using System.Windows;

namespace RoutedClickEvent
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            this.InitializeComponent();
        }

        private void StackPanel_SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void SimpleButton_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void SimpleButton_Click_Yes(object sender, RoutedEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void SimpleButton_Click_No(object sender, RoutedEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void AppendDebugOutput(string debugMessage)
        {
            this.DebugOutput.Text += $"{Environment.NewLine}{debugMessage}";
        }

        private string FormatRoutedEvent(object sender, RoutedEventArgs e)
        {
            return $"sender: {this.FormatTypeName(sender)}, e.Source: {this.FormatTypeName(e.Source)}, e.OriginalSource: {this.FormatTypeName(e.OriginalSource)}, e.RoutedEvent {e.RoutedEvent}";
        }

        private string FormatTypeName(object obj)
        {
            var typeName = $"{obj.GetType().Name}";
            return typeName;
        }
    }
}
