﻿using System;
using System.Windows.Data;

namespace WpfInputValidation.Converters
{
    public class BooleanOrConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach (var value in values)
            {
                if ((bool)value == true)
                {
                    return true;
                }
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack is not supported");
        }
    }
}
