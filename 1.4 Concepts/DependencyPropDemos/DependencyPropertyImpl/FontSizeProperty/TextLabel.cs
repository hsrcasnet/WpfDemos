using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace DependencyPropertySimple
{
    public class TextLabel : FrameworkElement
    {
        public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
            name: nameof(FontSize),
            propertyType: typeof(double),
            ownerType: typeof(TextLabel),
            typeMetadata: new FrameworkPropertyMetadata(
                defaultValue: 11.0,
                flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                propertyChangedCallback: OnFontSizePropertyChanged),
            validateValueCallback: new ValidateValueCallback(FontSizeValidator));

        public double FontSize
        {
            get => (double)this.GetValue(FontSizeProperty);
            set => this.SetValue(FontSizeProperty, value);
        }

        private static void OnFontSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine($"OnFontSizePropertyChanged:{Environment.NewLine}" +
                              $" -> Property.Name={e.Property.Name}{Environment.NewLine}" +
                              $" -> OldValue={e.OldValue}, NewValue={e.NewValue},");
        }

        private static bool FontSizeValidator(object value)
        {
            return value is double doubleValue && doubleValue > 0;
        }

        public TextLabel()
        {
            this.SubscibeToFontSizePropertyChange();
        }

        /// <summary>
        /// Demo: Alternative way to subscribe to value changes of a property at runtime.
        /// </summary>
        public void SubscibeToFontSizePropertyChange()
        {
            var dependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(dependencyProperty: FontSizeProperty, targetType: typeof(TextLabel));
            dependencyPropertyDescriptor.AddValueChanged(this, new EventHandler(this.SubscriptionToFontSizePropertyChanged));
        }

        private void SubscriptionToFontSizePropertyChanged(object sender, EventArgs args)
        {
            Console.WriteLine("SubscriptionToFontSizePropertyChanged");
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var formattedText = this.GetFormattedText();
            return new Size(formattedText.Width + 5, formattedText.Height + 5);
        }

        public string Text { get; set; } = "das ist ein default";

        private FormattedText GetFormattedText()
        {
            return
                new FormattedText(this.Text,
                    CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Arial"),
                    this.FontSize,
                    Brushes.Black);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(Brushes.LightGray, null, new Rect(this.RenderSize));

            var formattedText = this.GetFormattedText();
            drawingContext.DrawText(formattedText, new Point(2.5, 2.5));
        }
    }
}