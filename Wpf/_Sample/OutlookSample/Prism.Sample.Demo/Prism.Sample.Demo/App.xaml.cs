using System.Windows;

namespace Prism.Sample.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            BootStrapper bootstrapper = new BootStrapper();
            bootstrapper.Run();
        }
    }
}
