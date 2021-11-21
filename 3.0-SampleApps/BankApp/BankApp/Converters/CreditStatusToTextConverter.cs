using System;
using System.Globalization;
using BankApp.Enums;

namespace BankApp.Converters
{
    public class CreditStatusToTextConverter : BaseValueConverter<CreditStatusToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CreditStatus index)
            {
                switch (index)
                {
                    case CreditStatus.Annuity:
                        return "Annuity";
                    case CreditStatus.Differentiated:
                        return "Differentiated";
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
                    case "Annuity":
                        return CreditStatus.Annuity;
                    case "Differentiated":
                        return CreditStatus.Differentiated;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
