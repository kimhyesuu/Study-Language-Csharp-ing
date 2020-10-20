using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserList.Models;

namespace UserList.ViewModels
{
    public class UserListViewModel : BindableBase
    {
        //private IList<UserModel> _list;
        private IList<UserModel> _userlist;
        private UserModel _selectedUser;

        public IList<UserModel> Userlist
        {
            get { return _userlist; }
            set { SetProperty(ref _userlist, value); }
        }

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set { SetProperty(ref _selectedUser, value); }
        }

        public DelegateCommand _userUpdateCommand { get; private set; }

        public UserListViewModel()
        {
            //비교해보자
            _userlist = new ObservableCollection<UserModel>()
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

            CommonCommand();
        }

        private void CommonCommand()
        {
            _userUpdateCommand = new DelegateCommand(() => UserUpdate());
        }

        private void UserUpdate()
        {
            for (int i = 0; i < Userlist.Count; i++)
            {
                if(Userlist[i].UserId == SelectedUser.UserId)
                {
                    Userlist[i].FirstName = SelectedUser.FirstName;
                    Userlist[i].LastName = SelectedUser.LastName;
                    Userlist[i].City = SelectedUser.City;
                    Userlist[i].State = SelectedUser.State;
                    Userlist[i].Country = SelectedUser.Country;
                }
            }
        }
    }
}
