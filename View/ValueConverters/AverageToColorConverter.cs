using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AssistControl
{
    public class AverageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Convertimos el valor de entrada a double (valor origen).
            double average = (double)value;
            //Regresar el valor que se va a enlazar a la propiedad del elemento grafico (color).
            return average < 60 ? Color.Red : Color.Blue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
