using ElectionSystem.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ElectionSystem.Converters
{
    public class IntegerToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gender = (Gender)value;
            if (gender == Gender.Male) return 0;
            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 0) return Gender.Male;
            return Gender.Female;
        }
    }
}
