using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Behavior.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
   {



      public event PropertyChangedEventHandler PropertyChanged;

      private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
