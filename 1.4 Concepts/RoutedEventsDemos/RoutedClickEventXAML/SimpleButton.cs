﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RoutedClickEvent
{
    public class SimpleButton : ContentControl
    {
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
            name: nameof(Click),
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(RoutedEventHandler),
            ownerType: typeof(SimpleButton));

        public event RoutedEventHandler Click
        {
            add => this.AddHandler(ClickEvent, value);
            remove => this.RemoveHandler(ClickEvent, value);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            e.Handled = true;
            this.RaiseClickEvent();
        }

        private void RaiseClickEvent()
        {
            var eventArgs = new RoutedEventArgs(SimpleButton.ClickEvent);
            this.RaiseEvent(eventArgs);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            // Der SimpleButton soll mindestens 75 log. Einheiten breit und 23 hoch sein
            var desiredSize = new Size(75, 23);
            if (this.Content is UIElement child)
            {
                // Ist das Kindelement breiter oder höher, wird der entsprechende Wert des Kindelements
                // für die gewünschte Grösse des SimpleButton verwendet
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                desiredSize.Width = Math.Max(child.DesiredSize.Width, desiredSize.Width);
                desiredSize.Height = Math.Max(child.DesiredSize.Height, desiredSize.Height);
            }

            return desiredSize;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            // Damit der Button erkennbar ist, wird hier ein einfaches graues Rechteck mit einem schwarzen Rand gezeichnet.
            base.OnRender(drawingContext);
            drawingContext.DrawRectangle(
                Brushes.LightGray,
                new Pen(Brushes.Black, .5), 
                new Rect(this.RenderSize));
        }
    }
}