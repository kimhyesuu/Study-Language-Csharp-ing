using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Prism4Demo.ModuleB.Views
{
    /// <summary>
    /// Interaction logic for ModuleView.xaml
    /// </summary>
    public partial class ModuleBWorkspace : UserControl, IRegionMemberLifetime
    {
        #region Constructor

        public ModuleBWorkspace()
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
