using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomAttachedProperties1
{
    public class SimpleCanvas : Panel
    {
        public static readonly DependencyProperty LeftProperty;
        public static readonly DependencyProperty TopProperty;

        static SimpleCanvas()
        {
            LeftProperty =
                DependencyProperty.RegisterAttached("Left"
                    , typeof(double)
                    , typeof(SimpleCanvas)
                    , new FrameworkPropertyMetadata(0.0
                        , FrameworkPropertyMetadataOptions.AffectsParentMeasure));
            TopProperty =
                DependencyProperty.RegisterAttached("Top"
                    , typeof(double)
                    , typeof(SimpleCanvas)
                    , new FrameworkPropertyMetadata(0.0
                        , FrameworkPropertyMetadataOptions.AffectsParentMeasure));
        }

        [AttachedPropertyBrowsableForChildren]
        public static void SetLeft(UIElement element, double value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(LeftProperty, value);
        }

        [AttachedPropertyBrowsableForChildren]
        public static double GetLeft(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (double)element.GetValue(LeftProperty);
        }

        [AttachedPropertyBrowsableForChildren]
        public static void SetTop(UIElement element, double value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(TopProperty, value);
        }

        [AttachedPropertyBrowsableForChildren]
        public static double GetTop(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (double)element.GetValue(TopProperty);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size myDesiredSize = new Size();
            foreach (UIElement child in this.InternalChildren)
            {
                child.Measure(new Size(Double.PositiveInfinity
                    , Double.PositiveInfinity));
                double width = GetLeft(child)
                               + child.DesiredSize.Width;
                double height = GetTop(child)
                                + child.DesiredSize.Height;
                myDesiredSize.Width = Math.Max(width, myDesiredSize.Width);
                myDesiredSize.Height = Math.Max(height
                    , myDesiredSize.Height);
            }

            return myDesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Point location = new Point();
            foreach (UIElement child in this.InternalChildren)
            {
                location.X = GetLeft(child);
                location.Y = GetTop(child);
                child.Arrange(new Rect(location, child.DesiredSize));
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}