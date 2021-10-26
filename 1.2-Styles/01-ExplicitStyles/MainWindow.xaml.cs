using System.Windows;

namespace _01_ExplicitStyles
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            this.InitializeComponent();

            // Demo: Set dynamic resource from code-behind.
            // This is equivalent to the XAML code Style={DynamicResource MyButtonStyle}
            this.CancelButton.SetResourceReference(StyleProperty, "MyButtonStyle");

            // Demo: Load style resource and set it in code-behind
            var myStyle = this.FindResource("MyButtonStyleFromCode") as Style;
            this.TestButton.Style = myStyle;
        }
    }
}