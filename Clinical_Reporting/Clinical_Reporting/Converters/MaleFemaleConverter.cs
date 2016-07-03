using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Clinical_Reporting.Converters
{
    class MaleFemaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isMale = value as string;
            if (isMale == "Male" ||isMale=="male")
                return true;
            else
                return false;
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool ischecked = (bool)value;
            if (ischecked == true)
                return "Male";
            else
                return "Female";
        }
    }
}
