using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using YES.Mobile.Enums;

namespace YES.Mobile.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public string DisplayStatus;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Status status = (Status)Enum.Parse(typeof(Status), value.ToString(), true);

            switch (status)
            {
                case Status.Default:
                    DisplayStatus = "";
                    break;

                case Status.ToBeAnnounced:
                    DisplayStatus = "TBA";
                    break;

                case Status.Postponed:
                    DisplayStatus = "Postponed";
                    break;

                case Status.Relocated:
                    DisplayStatus = "New location!";
                    break;

                case Status.Cancelled:
                    DisplayStatus = "Cancelled";
                    break;

                case Status.Completed:
                    DisplayStatus = "Event already passed" +
                        "";
                    break;

                case Status.SoldOut:
                    DisplayStatus = "Sold out!";
                    break;

                default:
                    break;
            }

            return DisplayStatus;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}