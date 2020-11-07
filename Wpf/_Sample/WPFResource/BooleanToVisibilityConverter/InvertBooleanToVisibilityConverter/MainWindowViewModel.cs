using HsBarcode.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InvertBooleanToVisibilityConverter 
{
    internal static class CommandPara
    {
        internal const string buuuu = "buuuu";
        internal const string buuuu2 = "buuuu2";
    }


    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _isOpenVisible = true;

        public bool IsOpenVisible
        {
            get { return _isOpenVisible; }
            set
            {
                _isOpenVisible = value;
                OnPropertyChanged(nameof(IsOpenVisible));
            }
        }

        private bool _isCloseVisible = false;

        public bool IsCloseVisible
        {
            get { return _isCloseVisible; }
            set
            {
                _isCloseVisible = value;
                OnPropertyChanged(nameof(IsCloseVisible));
            }
        }

        public ICommand VisibilityCommand { get; private set; }

        public MainWindowViewModel()
        {
            VisibilityCommand = new RelayCommand( o => UpdateVisibility(o));
        }

        private void UpdateVisibility(object parameter)
        {
            if (parameter is null) return;

            var para = parameter as FrameworkElement;

            if (para.Name == CommandPara.buuuu || para.Name == CommandPara.buuuu2)
            {
                IsCloseVisible ^= true;
                IsOpenVisible ^= false;  
            }
       
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
