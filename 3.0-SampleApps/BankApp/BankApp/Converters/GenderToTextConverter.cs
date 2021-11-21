using System;
using System.Globalization;
using BankApp.Enums;

namespace BankApp.Converters
{
    public class GenderToTextConverter : BaseValueConverter<GenderToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Gender index)
            {
                switch (index)
                {
                    case Gender.Male:
                        return "Male";
                    case Gender.Female:
                        return "Female";
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
                    case "Male":
                        return Gender.Male;
                    case "Female":
                        return Gender.Female;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
