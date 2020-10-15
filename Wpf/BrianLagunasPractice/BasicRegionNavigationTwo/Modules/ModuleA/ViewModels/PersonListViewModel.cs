using ModuleA.Business;
using ModuleA.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace ModuleA.ViewModels
{
    // 첫번째 강의 : PersonListViewModel
    // 두번째 강의 : PersonDetailViewModel : INavigationAware
    // 세번째 강의 : PersonDetailViewModel : INavigationAware

    public class PersonListViewModel : BindableBase
    {
        IRegionManager _regionManager;
        private ObservableCollection<Person> _people;
   
        public PersonListViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            PersonSelectedCommand = new DelegateCommand<Person>(PersonSelected);
            CreatePeople();            
        }

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public DelegateCommand<Person> PersonSelectedCommand { get; private set; }

        private void PersonSelected(Person person)
        {
            if (person is null) return;

            var p = new NavigationParameters();
            p.Add("person",person);
            
            #region 두번째
            // 디버깅할 때 파라미터(p)가 안들어가서 시간 지체 좋은 발견이었다. 
            // 값이 잘들어가 있는지 확인해줘라 혜수야.....
            _regionManager.RequestNavigate("PersonDetailsRegion", "PersonDetail" , p);
            #endregion
            #region 첫번째로 쓴 것

            // NavigationParameters에 IEnumerable 상속이 되어있음 
            //var param = new NavigationParㅇameters();
            //param.Add("person",person);

            //if (person is null) return;

            //_regionManager.RequestNavigate("PersonDetailsRegion","PersonDetail", parameters);
            #endregion
        }

        #region 이 코드에서만 이렇게 하고 service in production code입니다. 하지만 강의를 위해서 여기다 쓴 것

        //원래는 CreatePeople()를 IPersonService에서 만드는 것
        // constructor에서 파라미터로 받아서 쓰는 것!!!!
        //PersonListViewModel(IPersonService personService)

        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();

            for(int i = 0; i < 10; i++)
            {
                people.Add(new Person()
                {
                    FirstName = $"First {i}",
                    LastName = $"Last {i}",
                    Age = i          
                });
            }

            People = people;
        }

        //private void parameters(NavigationResult obj)
        //{

        //}
        #endregion
    }
}
