using System.Windows;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Controls;

namespace DPAddOwner
{
  public class TextLabel:FrameworkElement
  {
    public static readonly DependencyProperty FontSizeProperty;
    public static readonly DependencyProperty TextProperty;

    static TextLabel()
    {
      FontSizeProperty =
       Control.FontSizeProperty.AddOwner(typeof(TextLabel));

      TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TextLabel)
         , new FrameworkPropertyMetadata(""
           , FrameworkPropertyMetadataOptions.AffectsRender
           | FrameworkPropertyMetadataOptions.AffectsMeasure)
           );
    }


    public double FontSize
    {
      get { return (double)GetValue(FontSizeProperty); }
      set { SetValue(FontSizeProperty,value); }
    }      

    public string Text
    {
      get { return (string)GetValue(TextProperty); }
      set { SetValue(TextProperty,value); }
    }

    protected override Size MeasureOverride(Size availableSize)
    {
      FormattedText txt = GetFormattedText();
      return new Size(txt.Width+5, txt.Height+5);
    }

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
