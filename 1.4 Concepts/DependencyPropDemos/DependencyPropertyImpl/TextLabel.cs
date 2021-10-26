using System.Windows;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Controls;
using System.ComponentModel;
using System;

namespace DependencyPropertySimple
{
  public class TextLabel: FrameworkElement
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


    private static bool FontSizeValidator(object value)
    {
      return (double)value > 0;
    }

    public double FontSize
    {
      get { return (double)GetValue(FontSizeProperty); }
      set { SetValue(FontSizeProperty,value); }
    }

    public  TextLabel()
    {
        test();
    }
 
    public void test() {
        DependencyPropertyDescriptor desc = DependencyPropertyDescriptor.FromProperty(FontSizeProperty, typeof(TextLabel));
        desc.AddValueChanged(this, new EventHandler(PropertyChanged));

    }
    private void PropertyChanged(object sender, EventArgs args)
    {
        Console.WriteLine("test");
    }

    protected override Size MeasureOverride(Size availableSize)
    {
      FormattedText txt = GetFormattedText();
      return new Size(txt.Width+5, txt.Height+5);
    }

    private string text = "das ist ein default";

    public string Text { get { return text; } set { text = value; } }
    
    private FormattedText GetFormattedText()
    {
      return
      new FormattedText(this.Text
        ,CultureInfo.InvariantCulture
        ,FlowDirection.LeftToRight
        ,new Typeface("Arial")
        ,this.FontSize
        ,Brushes.Black);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
      base.OnRender(drawingContext);

      drawingContext.DrawRectangle(Brushes.LightGray
                                  ,null
                                  ,new Rect(this.RenderSize));

      FormattedText txt = GetFormattedText();

      drawingContext.DrawText(txt, new Point(2.5, 2.5));
    }
  }

  
}
