using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace LocalizeDatesNumTextDirection
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            // using System.Globalization; CultureInfo
            // 일본 : ja-jp
            // 
            CultureInfo info = new CultureInfo("ar-IQ");
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;

            //using System.Windows.Markup; XmlLanguage 번역.Language
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name)));

            //FlowDirection
            //아직 습득 못함
            var flowDirection = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft ?
                FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            FrameworkElement.FlowDirectionProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(flowDirection));
        }
    }
}
