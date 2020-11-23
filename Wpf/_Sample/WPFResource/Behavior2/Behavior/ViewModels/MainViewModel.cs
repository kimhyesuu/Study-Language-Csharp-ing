using Behavior.Command;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Behavior.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
   {
      #region Private Fields
      private string _firstName;
      private string _lastName;
      #endregion

      #region Public Properties
      public string FirstName
      {
         get { return _firstName; }
         set
         {
            _firstName = value;
            OnPropertyChanged("FirstName");
         }
      }

      public string LastName
      {
         get { return _lastName; }
         set
         {
            _lastName = value;
            OnPropertyChanged("LastName");
         }
      }
      #endregion

      #region Commands
      RelayCommand _saveCommand;
      public ICommand SaveCommand
      {
         get
         {
            if (_saveCommand == null)
            {
               _saveCommand = new RelayCommand((param) => this.Save(param),
                   param => this.CanSave);
            }
            return _saveCommand;
         }
      }

      public void Save(object parameter)
      {
         string[] Names = ((string)parameter).Split( ':' );
         FirstName = Names[0];
         LastName = Names[1];
      }

      bool CanSave
      {
         get
         {
            return true;
         }
      }
      #endregion Commands

      #region INotifyPropertyChanged implementation
      public event PropertyChangedEventHandler PropertyChanged;
      public void OnPropertyChanged(string propertyName)
      {
         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
      }
      #endregion INotifyPropertyChanged implementation
   }
}
