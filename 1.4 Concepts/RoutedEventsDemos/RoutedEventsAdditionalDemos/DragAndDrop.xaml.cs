using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RoutedEvents
{
    public partial class DragAndDrop : System.Windows.Window
    {

        public DragAndDrop()
        {
            this.InitializeComponent();
        }

        private void OnSourceLabelMouseDown(object sender, MouseButtonEventArgs e)
        {
            var sourceLabel = (Label)sender;
            DragDrop.DoDragDrop(sourceLabel, sourceLabel.Content, DragDropEffects.Copy);
        }

        private void OnTargetLabelDrop(object sender, DragEventArgs e)
        {
            ((Label)sender).Content = e.Data.GetData(DataFormats.Text);
        }

        //private void lblTarget_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effects = e.Data.GetDataPresent(DataFormats.Text) ? DragDropEffects.Copy : DragDropEffects.None;
        //}
    }
}