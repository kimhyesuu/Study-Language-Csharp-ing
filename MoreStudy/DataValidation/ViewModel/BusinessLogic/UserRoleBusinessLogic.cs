namespace ViewModel.BusinessLogic
{
    using System.Linq;

    using DataModel;

    public static class UserRoleBusinessLogic
    {
        public static void AddUserRole(
            DatabaseContext databaseContext, UserRoleDataSet.UserRow userRow, UserRoleDataSet.RoleRow roleRow)
        {
            if (DatabaseContext.Instance.DataSet.UserRole.Any(x => x.UserRow == userRow && x.RoleRow == roleRow) == false)
            {
                DatabaseContext.Instance.DataSet.UserRole.AddUserRoleRow(userRow, roleRow);
            }
        }

        public static void DeleteUserRole(
            DatabaseContext databaseContext, UserRoleDataSet.UserRow userRow, UserRoleDataSet.RoleRow roleRow)
        {
            var userRole =
                DatabaseContext.Instance.DataSet.UserRole.FirstOrDefault(x => x.UserRow == userRow && x.RoleRow == roleRow);
            if (userRole != null)
            {
                // Delete the row.
                userRole.Delete();
            }
        }
    }
}