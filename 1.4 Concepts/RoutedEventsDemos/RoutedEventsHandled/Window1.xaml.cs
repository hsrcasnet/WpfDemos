using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace RoutedEventsHandled
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            this.InitializeComponent();
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
            e.Handled = true; // DEMO 1: What happens if we mark the event as handled here?
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void Rectangle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.AppendDebugOutput(this.FormatRoutedEvent(sender, e));
            e.Handled = true; // DEMO 2: What happens if we mark the event as handled here?
        }

        private void AppendDebugOutput(string debugMessage)
        {
            Debug.WriteLine(debugMessage);
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