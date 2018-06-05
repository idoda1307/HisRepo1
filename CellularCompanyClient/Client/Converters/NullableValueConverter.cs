using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Client.Converters
{
    public class NullableValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return null;
            double doubleVal;
            int intVal;

            if (int.TryParse(value.ToString(), out intVal))
            {
                return intVal;
            }
            else if (double.TryParse(value.ToString(), out doubleVal))
            {
                return doubleVal;
            }
            
            return null;
        }
    }
}
