using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Prism4Demo.ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ModuleView.xaml
    /// </summary>
    public partial class ModuleAWorkspace : UserControl, IRegionMemberLifetime
    {
        #region Constructor

        public ModuleAWorkspace()
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
