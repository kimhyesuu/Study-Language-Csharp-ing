namespace ViewModel.Users
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using DataModel;

    using ViewModel.BusinessLogic;
    using ViewModel.Users.DisplayItems;
    using ViewModel.Users.Notifications;

    public class UserGridViewModel
    {
        public UserGridViewModel()
        {
            this.UserDisplayItems = new ObservableCollection<UserDisplayItem>();
            this.UserDisplayItems.CollectionChanged += this.UserItemsOnCollectionChanged;
        }

        public ObservableCollection<UserDisplayItem> UserDisplayItems { get; private set; }

        public void InitializeDataHandling(DatabaseContext databaseContext)
        {
            this.GenerateDefaultColumns();

            foreach (var userRow in databaseContext.DataSet.User)
            {
                this.UserDisplayItems.Add(new UserDisplayItem(userRow));
            }
        }

        private void UserItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in notifyCollectionChangedEventArgs.NewItems)
                    {
                        if (newItem is UserDisplayItem)
                        {
                            UserDisplayItem roleItem = newItem as UserDisplayItem;
                            if (roleItem.DataObject == null)
                            {
                                roleItem.DataObject = UserBusinessLogic.AddNewUser();
                            }
                        }
                    }

                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in notifyCollectionChangedEventArgs.OldItems)
                    {
                        if (oldItem is UserDisplayItem)
                        {
                            UserDisplayItem userItem = oldItem as UserDisplayItem;
                            UserBusinessLogic.DeleteUser(userItem.DataObject);
                        }
                    }

                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void GenerateDefaultColumns()
        {
            this.AddTextColumn("First Name", "FirstName");
            this.AddTextColumn("Last Name", "LastName");
        }

        private void AddTextColumn(string header, string binding)
        {
            var addTextColumnNotification = new AddTextColumnNotification
            {
                Header = header,
                Binding = binding
            };
            DataColumnService.Instance.AddTextColumnRequest.Raise(addTextColumnNotification);
        }
    }
}