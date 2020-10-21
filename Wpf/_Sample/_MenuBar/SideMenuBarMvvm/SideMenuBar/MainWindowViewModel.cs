using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SideMenuBar
{
    public class MainWindowViewModel : INotifyPropertyChanged, ICommand
    {
        //두개의 버튼을 dependency property로 받으면 
        
        private object _IsVisible;

        public object IsVisible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                OnPropertyChanged();
            }
        }

        //public object IsVisibleClose
        //{
        //    get { return _IsVisible; }
        //    set
        //    {
        //        if()
        //        _IsVisible = value;
        //        OnPropertyChanged(nameof(());
        //    }
        //}

        
        //public ICommand VisbilityCommand
        //{
        //    get ;
        //    set
        //    {

        //    }
        //}
     

        void ExecuteCommandName()
        {

        }






        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
