using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfValueConversion.Converters
{
    public class BoolToColorBrushConverter : IValueConverter
    {
        public Color TrueColor { get; set; }

        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = Colors.Black;

            if (value is bool boolValue)
            {
                if (boolValue == true)
                {
                    color = TrueColor;
                }
                else
                {
                    color = FalseColor;
                }
            }

            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
