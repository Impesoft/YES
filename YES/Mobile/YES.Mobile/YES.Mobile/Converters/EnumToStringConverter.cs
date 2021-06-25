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
                    DisplayStatus = "Goan jonge";
                    break;

                case Status.ToBeAnnounced:
                    DisplayStatus = "Ge wet nog ni wnr ge kun goan jonge";
                    break;

                case Status.Postponed:
                    DisplayStatus = "'ff geduld voor ge kun goan jonge";
                    break;

                case Status.Relocated:
                    DisplayStatus = "Ge goat erges anders nrtoe mte goan jonge";
                    break;

                case Status.Cancelled:
                    DisplayStatus = "Tga nimr doorgoan jonge";
                    break;

                case Status.Completed:
                    DisplayStatus = "'Tis gedoan jonge";
                    break;

                case Status.SoldOut:
                    DisplayStatus = "Ge kun nimr goan jonge";
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