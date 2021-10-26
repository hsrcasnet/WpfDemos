using System.Windows;
using System.Windows.Media;

namespace _02_CustomControlDerivedFromFrameworkElement
{
    public class RoundedRectangle : FrameworkElement
    {
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register(
                "Fill",
                typeof(Brush),
                typeof(RoundedRectangle));

        public Brush Fill
        {
            get { return (Brush)this.GetValue(FillProperty); }
            set { this.SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty PenProperty =
            DependencyProperty.Register(
                "Pen",
                typeof(Pen),
                typeof(RoundedRectangle));

        //public static readonly DependencyProperty PenProperty =
        //    DependencyProperty.Register(
        //        "Pen",
        //        typeof(Pen),
        //        typeof(RoundedRectangle),
        //        new FrameworkPropertyMetadata(null, 
        //            FrameworkPropertyMetadataOptions.AffectsRender | 
        //            FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Pen Pen
        {
            get { return (Pen)this.GetValue(PenProperty); }
            set { this.SetValue(PenProperty, value); }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRoundedRectangle(this.Fill, this.Pen, new Rect(new Point(0, 0), this.RenderSize), 10, 10);
        }

        // Demo: Ensure minimum size if no content is present
        protected override Size MeasureOverride(Size availableSize)
        {
            var desiredSize = new Size(0, 0);
            if (this.Pen != null)
            {
                desiredSize.Width = this.Pen.Thickness * 2;
                desiredSize.Height = this.Pen.Thickness * 2;
            }

            return desiredSize;
        }
    }
}