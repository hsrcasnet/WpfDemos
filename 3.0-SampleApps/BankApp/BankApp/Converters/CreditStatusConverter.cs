using System;
using System.Globalization;
using BankApp.Enums;

namespace BankApp.Converters
{
    public class CreditStatusConverter : BaseValueConverter<CreditStatusConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CreditStatus index)
            {
                switch (index)
                {
                    case CreditStatus.Annuity:
                        return 0;
                    case CreditStatus.Differentiated:
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
                        return CreditStatus.Annuity;
                    case 1:
                        return CreditStatus.Differentiated;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
