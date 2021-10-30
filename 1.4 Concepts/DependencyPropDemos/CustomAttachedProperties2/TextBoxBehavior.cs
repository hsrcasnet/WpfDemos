using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomAttachedProperties2
{
    public static class TextBoxBehavior
    {
        public static readonly DependencyProperty SelectAllTextOnFocusProperty =
            DependencyProperty.RegisterAttached(
                name: "SelectAllTextOnFocus",
                propertyType: typeof(bool),
                ownerType: typeof(TextBoxBehavior),
                defaultMetadata: new UIPropertyMetadata(
                    defaultValue: false,
                    propertyChangedCallback: OnSelectAllTextOnFocusChanged));

        public static bool GetSelectAllTextOnFocus(TextBox textBox)
        {
            return (bool)textBox.GetValue(SelectAllTextOnFocusProperty);
        }

        public static void SetSelectAllTextOnFocus(TextBox textBox, bool value)
        {
            textBox.SetValue(SelectAllTextOnFocusProperty, value);
        }

        private static void OnSelectAllTextOnFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is TextBox textBox))
            {
                return;
            }

            if (!(e.NewValue is bool newValue))
            {
                return;
            }

            if (newValue)
            {
                textBox.GotFocus += OnTextBoxGotFocus;
                textBox.PreviewMouseDown += IgnoreMouseButton;
            }
            else
            {
                textBox.GotFocus -= OnTextBoxGotFocus;
                textBox.PreviewMouseDown -= IgnoreMouseButton;
            }
        }

        private static void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private static void IgnoreMouseButton(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is TextBox textBox) || textBox.IsKeyboardFocusWithin)
            {
                return;
            }

            e.Handled = true;
            textBox.Focus();
        }
    }
}