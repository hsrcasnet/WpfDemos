using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfValueConversion.Converters
{
    public class DatetimeToStringConverter : IValueConverter
    {
        /// <summary>
        /// Any string format which applies to DateTime values.
        /// https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
        /// </summary>
        public string Format { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime && !string.IsNullOrEmpty(this.Format))
            {
                return dateTime.ToString(this.Format);
            }
          
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           throw new NotSupportedException();
        }
    }
}