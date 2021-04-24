namespace ViewModel.Roles.DisplayItems
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DataModel;

    using SmallApplicationFramework.ViewModel;

    using ViewModel.Roles.DisplayItems.Validation;

    public class RoleDisplayItem : DataViewModelBase<UserRoleDataSet.RoleRow>
    {
        public RoleDisplayItem()
        {
        }

        public RoleDisplayItem(UserRoleDataSet.RoleRow roleRow)
        {
            if (this.DataObject != null)
            {
                throw new ApplicationException("The DataObject must be null");
            }

            this.DataObject = roleRow;
        }

        [Required(ErrorMessage = "Role name must be given")]
        [UniqueRoleName(ErrorMessage = "Role name must be unique")]
        public string Name { get; set; }
    }
}