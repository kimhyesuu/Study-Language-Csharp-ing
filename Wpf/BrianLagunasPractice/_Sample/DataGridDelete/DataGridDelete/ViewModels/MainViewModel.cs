using DataGridDelete.Command;
using DataGridDelete.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataGridDelete.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
   {
      public PersonViewModel PersonViewModel { get; }

      public MainViewModel()
      {
         PersonViewModel = new PersonViewModel();
      }

      public event PropertyChangedEventHandler PropertyChanged;

      protected void OnPropertyChanged(string name = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
   }
}
