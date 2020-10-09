using Prism.Mvvm;

namespace PrismOutlook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Mes System";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
