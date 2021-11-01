using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Data;

namespace WpfCurrentCulture.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public string Format { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToLocalTime().ToString(this.Format, Thread.CurrentThread.CurrentCulture);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
