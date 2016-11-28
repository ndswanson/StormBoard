using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace StormBoard.Converters
{
    class BooleanToVisibilityConverter : IValueConverter
    {
        private const string InvertString = @"Invert";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue;

            try
            {
                boolValue = (bool)value;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("The value provided cannot be cast to boolean", exception);
            }

            // Invert?
            var invert = IsInverted(parameter);

            // Return the value
            if (invert)
            {
                return boolValue ? Visibility.Collapsed : Visibility.Visible;
            }

            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility vis;

            try
            {
                vis = (Visibility)value;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("The value provided cannot be case to visibility", exception);
            }

            var invert = IsInverted(parameter);

            if (invert)
            {
                return vis == Visibility.Visible ? false : true;
            }

            return vis == Visibility.Visible ? true : false;
        }

        private static bool IsInverted(object parameter)
        {
            return parameter != null &&
                string.Compare(parameter.ToString(), InvertString, StringComparison.CurrentCultureIgnoreCase) == 0;
        }
    }
}
