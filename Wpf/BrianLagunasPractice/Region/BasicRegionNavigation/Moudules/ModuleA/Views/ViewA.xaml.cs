using Prism.Regions;
using System.Windows.Controls;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl, INavigationAware
    {
        public ViewA()
        {
            InitializeComponent();
        }

        int OnNavigatedToCount = 0;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            OnNavigatedToCount++;
            _txtPageViews2.Text = $"{OnNavigatedToCount}";

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        int OnNavigatedFromcount = 0;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            OnNavigatedFromcount++;
            _txtPageViews.Text = $"{OnNavigatedFromcount}";
        }
    }
}
