using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Data;

namespace WpfCurrentCulture.Converters
{
    public class DecimalToStringConverter : IValueConverter
    {
        public string Format { get; set; } = "N";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue.ToString(this.Format, Thread.CurrentThread.CurrentCulture);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
