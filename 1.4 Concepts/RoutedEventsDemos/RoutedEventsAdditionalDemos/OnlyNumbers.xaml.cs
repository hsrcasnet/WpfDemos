using System.Windows.Input;

namespace RoutedEvents
{
    public partial class OnlyNumbers : System.Windows.Window
    {

        public OnlyNumbers()
        {
            this.InitializeComponent();
        }

        private void OnStackPanelPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }
        }

        private void OnStackPanelPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}