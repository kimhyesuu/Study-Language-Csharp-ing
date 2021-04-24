namespace Application.Users.Converters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    using Application.Helpers;

    using DataModel;

    using ViewModel.BusinessLogic;
    using ViewModel.Users.DisplayItems;

    public class UserRoleValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = false;
            var dataGridCell = value as DataGridCell;
            if (dataGridCell != null)
            {
                var userItem = dataGridCell.DataContext as UserDisplayItem;
                if (userItem != null)
                {
                    var userRow = userItem.DataObject;
                    var role = ObjectTag.GetTag(dataGridCell.Column) as UserRoleDataSet.RoleRow;

                    if (role != null)
                    {
                        var checkBox = dataGridCell.Content as CheckBox;
                        if (checkBox != null)
                        {
                            if (dataGridCell.IsEditing)
                            {
                                checkBox.Checked += this.CheckBoxOnChecked;
                                checkBox.Unchecked += this.CheckBoxOnUnchecked;
                            }
                            else
                            {
                                checkBox.Checked -= this.CheckBoxOnChecked;
                                checkBox.Unchecked -= this.CheckBoxOnUnchecked;
                            }
                        }

                        result =
                            DatabaseContext.Instance.DataSet.UserRole.Any(
                                x => x.UserRow == userRow && x.RoleRow == role);
                    }
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private void CheckBoxOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                UserRoleDataSet.UserRow user;
                UserRoleDataSet.RoleRow role;
                if (this.GetUserAndRoleFromCheckBox(checkBox, out user, out role))
                {
                    UserRoleBusinessLogic.AddUserRole(DatabaseContext.Instance, user, role);
                }
            }
        }

        private void CheckBoxOnUnchecked(object sender, RoutedEventArgs routedEventArgs)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                UserRoleDataSet.UserRow user;
                UserRoleDataSet.RoleRow role;
                if (this.GetUserAndRoleFromCheckBox(checkBox, out user, out role))
                {
                    UserRoleBusinessLogic.DeleteUserRole(DatabaseContext.Instance, user, role);
                }
            }
        }

        private bool GetUserAndRoleFromCheckBox(
            CheckBox checkBox, out UserRoleDataSet.UserRow user, out UserRoleDataSet.RoleRow role)
        {
            user = null;
            role = null;

            var dataGridCell = ControlHelper.FindVisualParent<DataGridCell>(checkBox);
            if (dataGridCell != null && dataGridCell.IsEditing)
            {
                var userItem = dataGridCell.DataContext as UserDisplayItem;
                if (userItem != null)
                {
                    user = userItem.DataObject;
                    role = ObjectTag.GetTag(dataGridCell.Column) as UserRoleDataSet.RoleRow;
                }
            }

            return user != null && role != null;
        }
    }
}