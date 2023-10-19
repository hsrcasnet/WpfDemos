using System.Windows;
using System.Windows.Input;

namespace RoutedEvents
{
    public partial class MousePosition : System.Windows.Window
    {

        public MousePosition()
        {
            this.InitializeComponent();
        }


        private void cmdCapture_Click(object sender, RoutedEventArgs e)
        {
            this.AddHandler(
                   Mouse.LostMouseCaptureEvent,
                   new RoutedEventHandler(this.LostCapture));
            Mouse.Capture(this.rect);

            this.cmdCapture.Content = "[ Mouse is now captured ... ]";
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            var pt = e.GetPosition(this);
            this.lblInfo.Text =
                string.Format("You are at ({0},{1}) in window coordinates",
                pt.X, pt.Y);
        }

        private void LostCapture(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lost capture");
            this.cmdCapture.Content = "Capture the Mouse";
        }
    }
}