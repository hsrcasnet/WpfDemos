using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace RoutedEvents
{
    public partial class KeyModifiers : System.Windows.Window
    {
        public KeyModifiers()
        {
            this.InitializeComponent();
        }

        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            this.InfoLabel.Text = $"Modifiers: {e.KeyboardDevice.Modifiers}";

            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Debug.WriteLine("You press the Control key.");
            }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            this.InfoLabel.Text = $"The left shift key is currently {(Keyboard.IsKeyDown(Key.LeftShift) ? "" : "not ")}pressed.";
        }
    }
}