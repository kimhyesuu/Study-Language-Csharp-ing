using ModuleA.Business;
using ModuleA.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace ModuleA.ViewModels
{
    public class PersonListViewModel : BindableBase
    {
        IRegionManager _regionManager;
        private ObservableCollection<Person> _people;

        //원래는 CreatePeople()를 IPersonService에서 만드는 것
        // constructor에서 파라미터로 받아서 쓰는 것!!!!
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

        private DelegateCommand<Person> PersonSelectedCommand { get; set; }

        private void PersonSelected(Person person)
        {
            if (person is null) return;


            _regionManager.RequestNavigate("PersonDetailsRegion", "PersonDetail");


            // NavigationParameters에 IEnumerable 상속이 되어있음 
            //var param = new NavigationParㅇameters();
            //param.Add("person",person);

            //if (person is null) return;

            //_regionManager.RequestNavigate("PersonDetailsRegion","PersonDetail", parameters);
        }

        //이 코드에서만 이렇게 하고 service in production code이다 이건
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

    }
}
