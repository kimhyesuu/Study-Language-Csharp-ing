using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Prism4Demo.ModuleB.Views
{
    /// <summary>
    /// Interaction logic for ModuleTaskButton.xaml
    /// </summary>
    [ViewSortHint("02")]
    public partial class ModuleBTaskButton : UserControl
    {
        public ModuleBTaskButton(ModuleBTaskButtonViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
