using ModuleA.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class PersonDetailViewModel : BindableBase
    {
        public PersonDetailViewModel()
        {


        }

        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters["person"] as Person;
            if (person is null) return;
            SelectedPerson = person;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters["person"] as Person;
            if (person is null) return true;

            // return으로 이렇게 if 문식으로 할 수 있구나
            // SelectedPerson이 null이 아니고 SelectedPerson.LastName == person.LastName 
            return SelectedPerson != null && SelectedPerson.LastName == person.LastName;
        }

    }
}
