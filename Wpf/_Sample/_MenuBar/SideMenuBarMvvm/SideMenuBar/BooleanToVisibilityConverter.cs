using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SideMenuBar
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is Nullable<bool> && value is bool) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
        #region Ex1

        ///// <summary>
        ///// Convert bool or Nullable bool to Visibility
        ///// </summary>
        ///// <param name="value">bool or Nullable bool</param>
        ///// <param name="targetType">Visibility</param>
        ///// <param name="parameter">null</param>
        ///// <param name="culture">null</param>
        ///// <returns>Visible or Collapsed</returns>
        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    var bValue = false;
        //    if (value is bool)
        //    {
        //        bValue = (bool)value;
        //    }
        //    else if (value is Nullable<bool>)
        //    {
        //        Nullable<bool> tmp = (Nullable<bool>)value;
        //        bValue = tmp.HasValue ? tmp.Value : false;
        //    }
        //    return (bValue) ? Visibility.Visible : Visibility.Collapsed;
        //}

        ///// <summary>
        ///// Convert Visibility to boolean
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="targetType"></param>
        ///// <param name="parameter"></param>
        ///// <param name="culture"></param>
        ///// <returns></returns>
        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (value is Visibility)
        //    {
        //        return (Visibility)value == Visibility.Visible;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        #endregion
    }
}
