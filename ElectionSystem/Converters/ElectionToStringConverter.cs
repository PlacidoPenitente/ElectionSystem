using System;
using System.Globalization;
using System.Windows.Data;
using ElectionSystem.Models;

namespace ElectionSystem.Converters
{
    public class ElectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var election = (Election)value;
            if (election == null) return "";
                return election.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
