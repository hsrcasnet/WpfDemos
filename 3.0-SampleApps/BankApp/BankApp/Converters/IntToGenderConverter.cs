using System;
using System.Globalization;
using BankApp.Enums;

namespace BankApp.Converters
{
    public class IntToGenderConverter : BaseValueConverter<IntToGenderConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Gender index)
            {
                switch (index)
                {
                    case Gender.Male:
                        return 0;
                    case Gender.Female:
                        return 1;
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
                        return Gender.Male;
                    case 1:
                        return Gender.Female;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
