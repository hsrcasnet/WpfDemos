using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CollectionviewSourceSample
{
    public class BooleanVisiblityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool convParameter = this.GetConverterParameter(parameter);
            bool selected = (bool)value;

            return convParameter == selected ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Not Implemented");
        }

        #endregion

        private bool GetConverterParameter(object parameter)
        {
            try
            {
                bool convParameter = true;
                if (parameter != null)
                {
                    convParameter = System.Convert.ToBoolean(parameter);
                }

                return convParameter;
            }
            catch
            {
                return false;
            }
        }
    }
}