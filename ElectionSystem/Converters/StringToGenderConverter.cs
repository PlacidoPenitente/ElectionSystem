﻿using ElectionSystem.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ElectionSystem.Converters
{
    public class StringToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gender = (Gender)value;
            if (gender == Gender.Male) return "Male";
            return "Female";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals("Male")) return Gender.Male;
            return Gender.Female;
        }
    }
}