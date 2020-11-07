using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BooleanToVisibilityConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow()
        {
            FrameworkPropertyMetadata meta =
                new FrameworkPropertyMetadata(true,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);

            ShowMoreTextProperty =
                DependencyProperty.Register("ShowMoreText",
                typeof(bool), typeof(MainWindow), meta);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ShowMoreTextProperty;
        public bool ShowMoreText
        {
            get
            {
                return (bool)GetValue(ShowMoreTextProperty);
            }
            set
            {
                SetValue(ShowMoreTextProperty, value);
            }
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            //ShowMoreText = toggleButton.IsChecked.Value;
        }

        public static readonly DependencyProperty ShowMoreTextProperty =
           DependencyProperty.Register("ShowMoreText", typeof(bool),
           typeof(MainWindow), new FrameworkPropertyMetadata(true,
               FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool ShowMoreText
        {
            get
            {
                return (bool)GetValue(ShowMoreTextProperty);
            }
            set
            {
                SetValue(ShowMoreTextProperty, value);
            }
        }

    }
}
