using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace _03_CustomControlDerivedFromControl
{
    public class Clock : Control
    {
        private DispatcherTimer timer;

        static Clock()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Clock), new FrameworkPropertyMetadata(typeof(Clock)));
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.UpdateDateTime();

            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond);
            this.timer.Tick += this.Timer_Tick;
            this.timer.Start();
        }

        #region Business Methods

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.UpdateDateTime();

            this.timer.Interval = TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond);
            this.timer.Start();
        }

        private void UpdateDateTime()
        {
            this.DateTime = DateTime.Now;
        }

        #endregion

        #region DateTime property

        public DateTime DateTime
        {
            get { return (DateTime)this.GetValue(DateTimeProperty); }
            private set { this.SetValue(DateTimeProperty, value); }
        }

        public static DependencyProperty DateTimeProperty = DependencyProperty.Register(
            "DateTime",
            typeof(DateTime),
            typeof(Clock),
            new PropertyMetadata(DateTime.Now, new PropertyChangedCallback(OnDateTimeInvalidated)));

        public static readonly RoutedEvent DateTimeChangedEvent =
            EventManager.RegisterRoutedEvent("DateTimeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(Clock));

        protected virtual void OnDateTimeChanged(DateTime oldValue, DateTime newValue)
        {
            RoutedPropertyChangedEventArgs<DateTime> args = new RoutedPropertyChangedEventArgs<DateTime>(oldValue, newValue);
            args.RoutedEvent = DateTimeChangedEvent;
            this.RaiseEvent(args);
        }

        private static void OnDateTimeInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Clock clock = (Clock)d;

            DateTime oldValue = (DateTime)e.OldValue;
            DateTime newValue = (DateTime)e.NewValue;

            clock.OnDateTimeChanged(oldValue, newValue);
        }

        #endregion
    }
}