using System.ComponentModel;

namespace Prism.Sample.ModuleB.ViewModel
{
    public class BViewModel : INotifyPropertyChanged
    {
        public BViewModel()
        {
            ModuleBContent = "This is Left Region module(ModuleB loaded here), Basically we can use it to load any List items";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _moduleBContent;
        public string ModuleBContent
        {
            get => _moduleBContent;
            set
            {
                _moduleBContent = value;
                OnPropertyChanged(nameof(ModuleBContent));
            }
        }
    }
}
