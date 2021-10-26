using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfValueConversion.Converters
{
    public class DateTimeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.MinValue;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b == true)
            {
                return DateTime.Now;
            }

            return null;
        }
    }
}