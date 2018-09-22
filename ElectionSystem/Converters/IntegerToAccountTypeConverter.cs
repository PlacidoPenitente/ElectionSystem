using ElectionSystem.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ElectionSystem.Converters
{
    public class IntegerToAccountTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (AccountType)value;
            if (type == AccountType.Standard) return 0;
            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 0) return AccountType.Standard;
            return AccountType.Administrator;
        }
    }
}
