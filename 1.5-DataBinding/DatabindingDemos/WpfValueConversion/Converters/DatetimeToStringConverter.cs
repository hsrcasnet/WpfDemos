using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfValueConversion.Converters
{
    public class DatetimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return $"{dateTime:D}";
            }
          
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           throw new NotSupportedException();
        }
    }
}