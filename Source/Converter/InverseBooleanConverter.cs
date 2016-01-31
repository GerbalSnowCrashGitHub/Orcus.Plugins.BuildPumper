﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace BuildPumper.Converter
{
    [ValueConversion(typeof (bool), typeof (bool))]
    internal class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool) value);
        }
    }
}