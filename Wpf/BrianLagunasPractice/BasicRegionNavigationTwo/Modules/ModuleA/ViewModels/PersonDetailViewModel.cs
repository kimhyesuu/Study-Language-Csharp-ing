using ModuleA.Business;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleA.ViewModels
{

    public class PersonDetailViewModel : BindableBase, INavigationAware, IActiveAware
    {
        private Person _selectedPerson;

        public PersonDetailViewModel()
        {
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }

        public event EventHandler IsActiveChanged;

        private bool _isActive;
        //값이 왜와?
        //Gets or sets a value indicating whether the object is active.
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
            }
        }


        // INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // https://www.youtube.com/watch?v=anoK10sSPvE&t=4048s 1시간 13분
            if (navigationContext.Parameters.ContainsKey("person"))
            {
                SelectedPerson = navigationContext.Parameters.GetValue<Person>("person");
            }

            #region 강의에서 사용하지 않았던 코드입니다.
            //var person = navigationContext.Parameters["person"] as Person;
            //if (person is null) return;
            //SelectedPerson = person;
            #endregion
        }

        // 값이 있는지 계속 찾으며 false일때 view를 재생성합니다.
        // INavigationAware
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters.GetValue<Person>("person");

            if (person.LastName == SelectedPerson.LastName)
                return true;

            return false;
            #region 강의에서 사용하지 않았던 코드입니다.
            //var person = navigationContext.Parameters["person"] as Person;
            //if (person is null) return true;

            //// return으로 이렇게 if 문식으로 할 수 있구나
            //// SelectedPerson이 null이 아니고 SelectedPerson.LastName == person.LastName 
            //return SelectedPerson != null && SelectedPerson.LastName == person.LastName;
            #endregion
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

    }
}
