using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FBDTemp.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
   public class InvertConverter : IValueConverter
    {
        static InvertConverter()
        {
            Instance = new InvertConverter();
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(value as bool?);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(value as bool?);
        }
        public static InvertConverter Instance
        {
            get;
            private set;
        }
    }
}
