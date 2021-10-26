using System.Windows;

namespace FontSizeDepProp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        bool state = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // ValueSource source = DependencyPropertyHelper.GetValueSource(this.txtLbl, FontSizeDepProp.TextLabel.FontSizeProperty);
  
            if (state)
                txtLbl.ClearValue(FontSizeDepProp.TextLabel.FontSizeProperty);
            else
                this.txtLbl.FontSize = 8;
            state = !state;
        }
    }
}
