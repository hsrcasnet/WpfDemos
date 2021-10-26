using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using SnooperLib;
using WPFHelpers;

namespace EventsAndCommandsDemo
{
    public partial class EventsWindow : Window
    {
        public EventsWindow()
        {
            this.InitializeComponent();
            //AddHandler(UIElement.MouseLeftButtonDownEvent, (RoutedEventHandler)WindowLevelMouseDownCallMeAlwaysHandler, true);
            //m_Image.AddHandler(UIElement.MouseLeftButtonDownEvent, (RoutedEventHandler)ImageMouseLeftButtonDownHandler);
            //m_Text.AddHandler(UIElement.MouseLeftButtonDownEvent, (RoutedEventHandler)ButtonMouseLeftButtonDownHandler);
            this.Loaded += new RoutedEventHandler(this.Window1_Loaded);
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            var snooper = new SnooperDialog()
            {
                Owner = this,
                TargetElement = this,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            snooper.Show();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            VisualLogicalTree.DisplayLogicalTree(this);
            //  WPFHelpers.VisualLogicalTree.DisplayVisualTree(this);
        }
        //protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        //{
        //    base.OnMouseLeftButtonDown(e);
        //    Debug.WriteLine(String.Format("override OnMouseLeftButtonDown Source: {0} OriginalSource {1}",
        //    e.Source.ToString(), e.OriginalSource.ToString()));
        //}

        private void ButtonMouseLeftButtonDownHandler(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button mouse left button down event");
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button Click event, XAML hookup----------------- ");
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
            e.Handled = true;
        }

        private void ImageMouseLeftButtonDownHandler(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Image mouse left button down event");
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
            e.Handled = true;
        }

        private void WindowLevelMouseDownCallMeAlwaysHandler(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("Window level handler that gets called always");
            Debug.WriteLine(String.Format("Hu: Window level handler that gets called always"));
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Grid preview mouse left button down event, XAML hookup");
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void InnerImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Image Element mouse left button down event, XAML hookup");
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void InnerTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Button mouse left button down event");
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
            e.Handled = true;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(string.Format("Hu: Button Click attached event , XAML hookup Source"));
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
        }

        private void InnerButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Inner Button Click event, XAML hookup----------------- ");
            AppendDebugOutput(this.FormatRoutedEvent(sender, e));
            // e.Handled = true;
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