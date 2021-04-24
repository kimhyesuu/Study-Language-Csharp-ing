namespace ViewModel.Users.DisplayItems
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DataModel;

    using SmallApplicationFramework.ViewModel;

    public class UserDisplayItem : DataViewModelBase<UserRoleDataSet.UserRow>
    {
        public UserDisplayItem()
        {
        }

        public UserDisplayItem(UserRoleDataSet.UserRow userRow)
        {
            if (this.DataObject != null)
            {
                throw new ApplicationException("The DataObject must be null");
            }

            this.DataObject = userRow;
        }

        [Required(ErrorMessage = "The first name must be given")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name must be given")]
        public string LastName { get; set; }
    }
}