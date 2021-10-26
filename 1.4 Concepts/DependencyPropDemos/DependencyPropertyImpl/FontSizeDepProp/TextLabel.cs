using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace FontSizeDepProp
{
    public class TextLabel : FrameworkElement
    {
        public static readonly DependencyProperty FontSizeProperty;

        static TextLabel()
        {
            FontSizeProperty =
                DependencyProperty.Register("FontSize"
                    , typeof(double)
                    , typeof(TextLabel)
                    , new FrameworkPropertyMetadata(11.0, FrameworkPropertyMetadataOptions.AffectsMeasure)
                    , new ValidateValueCallback(FontSizeValidator));
        }

        [AttachedPropertyBrowsableForChildren]
        public static void SetFontSize(UIElement element, double value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(FontSizeProperty, value);
        }

        [AttachedPropertyBrowsableForChildren]
        public static double GetFontSize(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (double)element.GetValue(FontSizeProperty);
        }

        private static bool FontSizeValidator(object value)
        {
            return (double)value > 0;
        }

        public double FontSize
        {
            get { return (double)this.GetValue(FontSizeProperty); }
            set { this.SetValue(FontSizeProperty, value); }
        }

        public TextLabel()
        {
            this.test();
        }

        public void test()
        {
            DependencyPropertyDescriptor desc = DependencyPropertyDescriptor.FromProperty(FontSizeProperty, typeof(TextLabel));
            desc.AddValueChanged(this, new EventHandler(this.PropertyChanged));
        }

        private void PropertyChanged(object sender, EventArgs args)
        {
            Console.WriteLine("test");
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            FormattedText txt = this.GetFormattedText();
            return new Size(txt.Width + 5, txt.Height + 5);
        }

        public string Text { get; set; } = "das ist ein default";

        private FormattedText GetFormattedText()
        {
            return
                new FormattedText(this.Text
                    , CultureInfo.InvariantCulture
                    , FlowDirection.LeftToRight
                    , new Typeface("Arial")
                    , this.FontSize
                    , Brushes.Black);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(Brushes.LightGray
                , null
                , new Rect(this.RenderSize));

            FormattedText txt = this.GetFormattedText();

            drawingContext.DrawText(txt, new Point(2.5, 2.5));
        }
    }
}