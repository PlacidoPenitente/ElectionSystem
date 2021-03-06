﻿using System;
using System.Globalization;
using System.Windows.Data;
using ElectionSystem.Models;

namespace ElectionSystem.Converters
{
    public class ElectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(string))
            {
                var election = (Election)value;
                return election.Name;
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
