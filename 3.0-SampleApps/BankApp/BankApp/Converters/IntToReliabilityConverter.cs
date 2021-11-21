using System;
using System.Globalization;
using BankApp.Enums;

namespace BankApp.Converters
{
    public class IntToReliabilityConverter : BaseValueConverter<IntToReliabilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Reliability index)
            {
                switch (index)
                {
                    case Reliability.Low:
                        return 0;
                    case Reliability.Medium:
                        return 1;
                    case Reliability.High:
                        return 2;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                switch (index)
                {
                    case 0:
                        return Reliability.Low;
                    case 1:
                        return Reliability.Medium;
                    case 2:
                        return Reliability.High;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
