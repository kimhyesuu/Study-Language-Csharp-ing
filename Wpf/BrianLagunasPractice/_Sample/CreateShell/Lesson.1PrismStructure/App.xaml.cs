using System.Windows;
using Lesson._1PrismStructure.Views;
using Prism.DryIoc;
using Prism.Ioc;

namespace Lesson._1PrismStructure
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
