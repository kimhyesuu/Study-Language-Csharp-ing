using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingDelegateCommand.ViewModels
{
   public class MainWindowViewModel : BindableBase
   {
      public bool IsEnabled
      {
         get => true;
         set
         {
            ExecuteGenericDelegateCommand.RaiseCanExecuteChanged();
         }
      }
      
      private string _updateText;
      public string UpdateText
      {
         get { return _updateText; }
         set { SetProperty(ref _updateText, value); }
      }

      private string _firstName;
      private string _lastName;

      public string FirstName
      {
         get { return _firstName; }
         set { SetProperty(ref _firstName, value); }
      }

      public string LastName
      {
         get { return _lastName; }
         set { SetProperty(ref _lastName, value); }
      }

      public DelegateCommand ExecuteDelegateCommand { get; private set; }

      public DelegateCommand<string> ExecuteGenericDelegateCommand { get; private set; }

      public DelegateCommand DelegateCommandObservesProperty { get; private set; }

      public DelegateCommand DelegateCommandObservesCanExecute { get; private set; }


      public MainWindowViewModel()
      {
         ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);

         DelegateCommandObservesProperty = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsEnabled);

         DelegateCommandObservesCanExecute = new DelegateCommand(Execute).ObservesCanExecute(() => IsEnabled);

         ExecuteGenericDelegateCommand = new DelegateCommand<string>(ExecuteGeneric).ObservesCanExecute(() => IsEnabled);
      }

      private void Execute()
      {
         UpdateText = $"Updated: {DateTime.Now}";
      }

      private void ExecuteGeneric(string parameter)
      {
         string[] Names = ((string)parameter).Split(new char[] { ':' });
         FirstName = Names[0];
         LastName = Names[1];

         UpdateText = $"{FirstName} {LastName}";
      }

      private bool CanExecute()
      {
         return IsEnabled;
      }
   }
}
