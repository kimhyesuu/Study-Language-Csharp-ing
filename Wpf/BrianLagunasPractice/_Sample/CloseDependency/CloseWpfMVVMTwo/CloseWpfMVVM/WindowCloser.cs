using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CloseWpfMVVM
{
    public class WindowCloser
    {
        //public bool MyProperty
        //{
        //    get { return (bool)GetValue(MyPropertyProperty); }
        //    set { SetValue(EnabledWindowClosing, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty EnabledWindowClosing =
        //    DependencyProperty.Register("EnabledWindowClosing", typeof(bool), typeof(WindowCloser), new PropertyMetadata(false, OnEnabledWindowClosingChanged));

        public static bool GetEnabledWindowClosing(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnabledWindowClosing);
        }

        public static void SetEnabledWindowClosing(DependencyObject obj, bool value)
        {
            obj.SetValue(EnabledWindowClosing, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledWindowClosing =
            DependencyProperty.RegisterAttached("EnabledWindowClosing", typeof(bool), typeof(WindowCloser), new PropertyMetadata(false, OnEnabledWindowClosingChanged));

        private static void OnEnabledWindowClosingChanged(DependencyObject d, DependencyPropertyChangedEventArgs dc)
        {
            if (d is Window window)
            {
                window.Loaded += (s, e) =>
                {
                    if (window.DataContext is IWindowResource vm)
                    {
                        vm.Close += () =>
                        {
                            window.Close();
                        };

                        window.Closing += (sender, closeevent) =>
                        {
                            // 이벤트를 취소해야하는 경우 true입니다. 그렇지 않으면 거짓입니다.
                            closeevent.Cancel = !vm.CanClose();
                        };
                    }
                };
            }
        }
    }

}
