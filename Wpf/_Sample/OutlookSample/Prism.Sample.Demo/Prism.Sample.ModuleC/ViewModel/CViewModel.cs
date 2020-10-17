using System.ComponentModel;

namespace Prism.Sample.ModuleC.ViewModel
{
    public class CViewModel : INotifyPropertyChanged
    {
        public CViewModel()
        {
            ModuleCContent = "This is Main Region module(ModuleC loaded here), Basically we can use it to put usercontrol/form/document";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _moduleCContent;
        public string ModuleCContent
        {
            get => _moduleCContent;
            set
            {
                _moduleCContent = value;
                OnPropertyChanged(nameof(ModuleCContent));
            }
        }
    }
}

