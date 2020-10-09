using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Prism4Demo.ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ModuleANavigator.xaml
    /// </summary>
    public partial class ModuleANavigator : UserControl, IRegionMemberLifetime
    {
        #region Constructor

        public ModuleANavigator()
        {
            InitializeComponent();
        }

        #endregion

        #region IRegionMemberLifetime Members

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion
    }
}
