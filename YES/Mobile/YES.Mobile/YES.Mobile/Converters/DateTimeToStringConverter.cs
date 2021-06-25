using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using YES.Mobile.Dto;

namespace YES.Mobile.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public string ToBeAnnounced;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((DateTime)value == DateTime.MinValue)
            {
                ToBeAnnounced = "To Be Announced";
                return ToBeAnnounced;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}