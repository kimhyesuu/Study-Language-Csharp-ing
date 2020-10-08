using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemoUI.Models;

namespace WPFDemoUI.ViewModels
{
   public class ShellViewModel : Conductor<object>
   {
      private string _firstName = "Tim";
      private string _lastName;
      private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
      private PersonModel _selectedPerson;

      public ShellViewModel()
      {
         People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
         People.Add(new PersonModel { FirstName = "kim", LastName = "hyesu" });
         People.Add(new PersonModel { FirstName = "kim2", LastName = "hyesu2" });
         People.Add(new PersonModel { FirstName = "kim2", LastName = "hyesu3" });
      }

      public string FirstName
      {
         get => _firstName;
         set
         {
            _firstName = value;
            NotifyOfPropertyChange(()=> FirstName);
            NotifyOfPropertyChange(() => FullName);
         }
      }

      public string LastName
      {
         get { return _lastName; }
         set
         {
            _lastName = value;
            NotifyOfPropertyChange(() => LastName);
            NotifyOfPropertyChange(() => FullName);
         }
      }

      public string FullName
      {
         get { return $"{FirstName} {LastName}"; }   
      }

      public BindableCollection<PersonModel> People
      {
         get { return _people; }
         set { _people = value; }
      }

      public PersonModel SelectedPerson
      {
         get { return _selectedPerson; }
         set
         {
            _selectedPerson = value;
            NotifyOfPropertyChange(()=> SelectedPerson);
         }
      }

      public bool CanClearText(string firstName, string lastName) // => !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
      {
         if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            return false;
         return true;
      }

      public void ClearTextMethod(string firstName, string lastName)
      {
         if (CanClearText(firstName, lastName) == false)
            return;
         FirstName = string.Empty;
         LastName = string.Empty;
      }

      public void LoadPageOne()
      {
         ActivateItem(new FirstChildViewModel());
      }

      public void LoadPageTwo()
      {
         ActivateItem(new SecondChildViewModel());
      }
   }
}
