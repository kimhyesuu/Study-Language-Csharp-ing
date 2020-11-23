using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace UsingDelegateCommand
{
   public class Converters : IMultiValueConverter
   {
      public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         var sRes = values.OfType<string>().ToArray();
         var sb = new StringBuilder();

         sb.Append(string.Join(":", sRes));
   
         return sb.ToString();
      }

      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
      {
         throw new NotImplementedException();
      }
   }
}
