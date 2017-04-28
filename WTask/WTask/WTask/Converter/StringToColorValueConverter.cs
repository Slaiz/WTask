using System;
using System.Globalization;
using Xamarin.Forms;

namespace WTask.Converter
{
    public class StringToColorValueConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            Color color = Color.FromHex(((string)value));
            return color;          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}