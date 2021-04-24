namespace ViewModel.Roles
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Data;

    using DataModel;

    using ViewModel.BusinessLogic;
    using ViewModel.Roles.DisplayItems;
    using ViewModel.Users;
    using ViewModel.Users.Notifications;

    public class RoleGridViewModel
    {
        public RoleGridViewModel()
        {
            this.RoleDisplayItems = new ObservableCollection<RoleDisplayItem>();
            this.RoleDisplayItems.CollectionChanged += this.RoleItemsOnCollectionChanged;
        }

        public ObservableCollection<RoleDisplayItem> RoleDisplayItems { get; private set; }

        public void InitializeDataHandling(DatabaseContext databaseContext)
        {
            databaseContext.DataSet.Role.RoleRowChanged += this.RoleOnRowChanged;
            databaseContext.DataSet.Role.RoleRowDeleted += this.RoleOnRoleRowDeleted;

            foreach (var roleRow in databaseContext.DataSet.Role)
            {
                this.RoleDisplayItems.Add(new RoleDisplayItem(roleRow));
                this.AddRoleColumn(roleRow);
            }
        }

        private void RoleItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in notifyCollectionChangedEventArgs.NewItems)
                    {
                        if (newItem is RoleDisplayItem)
                        {
                            RoleDisplayItem roleItem = newItem as RoleDisplayItem;
                            if (roleItem.DataObject == null)
                            {
                                roleItem.DataObject = RoleBusinessLogic.AddNewRole();
                            }
                        }
                    }

                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in notifyCollectionChangedEventArgs.OldItems)
                    {
                        if (oldItem is RoleDisplayItem)
                        {
                            RoleDisplayItem roleItem = oldItem as RoleDisplayItem;
                            RoleBusinessLogic.DeleteRole(roleItem.DataObject);
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

        private void RoleOnRowChanged(object sender, UserRoleDataSet.RoleRowChangeEvent roleRowChangeEvent)
        {
            switch (roleRowChangeEvent.Action)
            {
                case DataRowAction.Change:
                    this.ChangeRoleColumn(roleRowChangeEvent.Row);
                    break;
                case DataRowAction.Add:
                    this.AddRoleColumn(roleRowChangeEvent.Row);
                    break;
            }
        }

        private void RoleOnRoleRowDeleted(object sender, UserRoleDataSet.RoleRowChangeEvent roleRowChangeEvent)
        {
            if (roleRowChangeEvent.Action == DataRowAction.Delete)
            {
                this.DeleteRoleColumn(roleRowChangeEvent.Row);
            }
        }

        private void AddRoleColumn(UserRoleDataSet.RoleRow roleRow)
        {
            var notification = new AddDynamicColumnNotification { Role = roleRow };
            DataColumnService.Instance.AddDynamicColumnRequest.Raise(notification);
        }

        private void ChangeRoleColumn(UserRoleDataSet.RoleRow roleRow)
        {
            var notification = new ChangeDynamicColumnNotification { Role = roleRow };
            DataColumnService.Instance.ChangeDynamicColumnRequest.Raise(notification);
        }

        private void DeleteRoleColumn(UserRoleDataSet.RoleRow roleRow)
        {
            var notification = new DeleteDynamicColumnNotification { Role = roleRow };
            DataColumnService.Instance.DeleteDynamicColumnRequest.Raise(notification);
        }
    }
}