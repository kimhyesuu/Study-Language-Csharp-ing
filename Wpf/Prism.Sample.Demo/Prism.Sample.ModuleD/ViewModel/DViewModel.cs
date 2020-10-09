using System.ComponentModel;

namespace Prism.Sample.ModuleD.ViewModel
{
    public class DViewModel : INotifyPropertyChanged
    {
        public DViewModel()
        {
            ModuleDContent = "This is Bottom Region module(ModuleD loaded here), Basically we can use it to display logs/info";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _moduleDContent;
        public string ModuleDContent
        {
            get => _moduleDContent;
            set
            {
                _moduleDContent = value;
                OnPropertyChanged(nameof(ModuleDContent));
            }
        }
    }
}

