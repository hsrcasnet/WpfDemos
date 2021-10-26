using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnooperLib
{
    public class SelectionAdorner : Adorner
    {
        static SelectionAdorner()
        {
            _Brush = new SolidColorBrush(new Color
            {
                A = 127, R = 42, G = 200, B = 0
            });
        }

        public SelectionAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            this._rectangle = new Rectangle
            {
                IsHitTestVisible = false,
                Stroke = _Brush,
                StrokeThickness = 5
            };
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return this._rectangle;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            this._rectangle.Measure(constraint);
            return this._rectangle.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var bounds = VisualTreeHelper.GetDescendantBounds(this.AdornedElement);

            if (!bounds.IsEmpty)
            {
                this._rectangle.Arrange(bounds);
            }

            return this._rectangle.DesiredSize;
        }

        readonly Rectangle _rectangle;
        readonly static SolidColorBrush _Brush;
    }
}