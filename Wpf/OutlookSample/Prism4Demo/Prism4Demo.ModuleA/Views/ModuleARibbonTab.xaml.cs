using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace Prism4Demo.ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ModuleARibbonTab.xaml
    /// </summary>
    public partial class ModuleARibbonTab : RibbonTab, IRegionMemberLifetime
    {
        #region Constructor

        public ModuleARibbonTab()
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
