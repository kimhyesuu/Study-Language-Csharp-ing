namespace ViewModel.BusinessLogic
{
    using DataModel;

    public static class UserBusinessLogic
    {
         public static UserRoleDataSet.UserRow AddNewUser()
         {
             // Create and initialize the new row.
             var userRow = DatabaseContext.Instance.DataSet.User.NewUserRow();
             userRow.FirstName = string.Empty;
             userRow.LastName = string.Empty;
             DatabaseContext.Instance.DataSet.User.AddUserRow(userRow);
             return userRow;
         }

        public static void DeleteUser(UserRoleDataSet.UserRow userRow)
        {
            // Delete the row.
            userRow.Delete();
        }
    }
}