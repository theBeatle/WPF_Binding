using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Binding_09_toConverter
{
    // Интерфейс для добавления пользовательской логики при привязке данных.
    public class MyConverter : IValueConverter
    {
        // Parameters:
        //   value:
        //     value from source
        //
        //   targetType:
        //      type to be returned
        //
        //   parameter:
        //     additional parameters
        //
        //   culture:
        //     culture :-)
        //
        // Returns:
        //     converted value

        /// from source to aim
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int number = System.Convert.ToInt32(value);
            switch (number)
            {
                case 0:
                    return "Zero";
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                default:
                    return "ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string numberString = value.ToString();
            switch (numberString)
            {

                case "Zero":
                    return 0;
                case "One":
                    return 1;
                case "Two":
                    return 2;
                case "Three":
                    return 3;
                case "Four":
                    return 4;
                case "Five":
                    return 5;
                case "Error":
                    return 10;
                default:
                    return 0;
            }
        }
    }

}
