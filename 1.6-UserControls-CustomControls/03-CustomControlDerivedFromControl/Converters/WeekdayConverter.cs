using System;
using System.Globalization;
using System.Windows.Data;

namespace _03_CustomControlDerivedFromControl.Converters
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class WeekdayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.DayOfWeek.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}