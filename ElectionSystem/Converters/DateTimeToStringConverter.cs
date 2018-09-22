using System;
using System.Globalization;
using System.Windows.Data;

namespace ElectionSystem.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? DateTime.Now.ToShortDateString() : ((DateTime) value).Date.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DateTime.Now;
            try
            {
                return DateTime.Parse((string) value);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
    }
}
