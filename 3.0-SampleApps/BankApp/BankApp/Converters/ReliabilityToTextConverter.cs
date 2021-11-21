using System;
using System.Globalization;
using BankApp.Enums;

namespace BankApp.Converters
{
    public class ReliabilityToTextConverter : BaseValueConverter<ReliabilityToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Reliability index)
            {
                switch (index)
                {
                    case Reliability.Low:
                        return "Low";
                    case Reliability.Medium:
                        return "Medium";
                    case Reliability.High:
                        return "High";
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string index)
            {
                switch (index)
                {
                    case "Low":
                        return Reliability.Low;
                    case "Medium":
                        return Reliability.Medium;
                    case "High":
                        return Reliability.High;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
