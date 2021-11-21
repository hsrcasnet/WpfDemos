using System;
using System.Globalization;
using BankApp.Enums;

namespace BankApp.Converters
{
    public class DepositStatusConverter : BaseValueConverter<DepositStatusConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DepositStatus index)
            {
                switch (index)
                {
                    case DepositStatus.WithoutCapitalization:
                        return 0;
                    case DepositStatus.WithCapitalization:
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
                        return DepositStatus.WithoutCapitalization;
                    case 1:
                        return DepositStatus.WithCapitalization;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
