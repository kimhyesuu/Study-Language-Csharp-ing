using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserList.Models;

namespace UserList.ViewModels
{
    public class UserListViewModel : BindableBase
    {
        //private IList<UserModel> _list;
        private IList<UserModel> _userlist;

        public IList<UserModel> Userlist
        {
            get { return _userlist; }
            set { SetProperty(ref _userlist, value); }
        }

        public UserListViewModel()
        {
            //비교해보자
            _userlist = new List<UserModel>()
            {
                new UserModel { UserId = 1, FirstName = "Raj", LastName = "Beniwal", City = "Delhi", State = "DEL", Country = "INDIA" },
                new UserModel { UserId = 2, FirstName = "Mark", LastName = "henry", City = "New York", State = "NY", Country = "USA" },
                new UserModel { UserId = 3, FirstName = "Mahesh", LastName = "Chand", City = "Philadelphia", State = "PHL", Country = "USA" },
                new UserModel { UserId = 4, FirstName = "Vikash", LastName = "Nanda", City = "Noida", State = "UP", Country = "INDIA" },
                new UserModel { UserId = 5, FirstName = "Harsh", LastName = "Kumar", City = "Ghaziabad", State = "UP", Country = "INDIA" },
                new UserModel { UserId = 6, FirstName = "Reetesh", LastName = "Tomar", City = "Mumbai", State = "MP", Country = "INDIA" },
                new UserModel { UserId = 7, FirstName = "Deven", LastName = "Verma", City = "Palwal", State = "HP", Country = "INDIA" },
                new UserModel { UserId = 8, FirstName = "Ravi", LastName = "Taneja", City = "Delhi", State = "DEL", Country = "INDIA" }
            };
        }

    }
}
