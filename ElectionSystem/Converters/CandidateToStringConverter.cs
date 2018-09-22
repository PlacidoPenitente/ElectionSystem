using System;
using System.Globalization;
using System.Windows.Data;
using ElectionSystem.Models;

namespace ElectionSystem.Converters
{
    public class CandidateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType()!=typeof(String))
            {
                var candidate = (Voter)value;
                return candidate.LastName + ", " + candidate.FirstName + " " + candidate.MiddleName;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
