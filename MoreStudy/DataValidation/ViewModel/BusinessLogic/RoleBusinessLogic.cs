namespace ViewModel.BusinessLogic
{
    using System.Linq;

    using DataModel;

    public static class RoleBusinessLogic
    {
        public static UserRoleDataSet.RoleRow AddNewRole()
        {
            // Create and initialize the new row.
            var roleRow = DatabaseContext.Instance.DataSet.Role.NewRoleRow();
            roleRow.Name = string.Empty;
            DatabaseContext.Instance.DataSet.Role.AddRoleRow(roleRow);
            return roleRow;
        }

        public static void DeleteRole(UserRoleDataSet.RoleRow roleRow)
        {
            // Delete the row.
            roleRow.Delete();
        }

        public static bool IsRoleNameUnique(string name, UserRoleDataSet.RoleRow roleRow)
        {
            // Test if the name is unique within the rows of the same table.
            var table = roleRow.Table as UserRoleDataSet.RoleDataTable;
            return name != null && table != null && table.Any(x => x.Name == name && x != roleRow);
        }
    }
}