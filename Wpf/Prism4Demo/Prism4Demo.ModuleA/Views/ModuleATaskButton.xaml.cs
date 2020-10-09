using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using Prism4Demo.ModuleA.ViewModels;

namespace Prism4Demo.ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ModuleATaskButton.xaml
    /// </summary>
    [ViewSortHint("01")]
    public partial class ModuleATaskButton : UserControl
    {
        public ModuleATaskButton(ModuleATaskButtonViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
