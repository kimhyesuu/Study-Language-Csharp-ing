namespace DataModel
{
    using System.IO;

    /// <summary>
    /// The data context as a singleton instance.
    /// </summary>
    public class DatabaseContext
    {
        private const string DatabaseFileName = "UserRoles.xml";

        private static DatabaseContext instance;

        private DatabaseContext()
        {
            this.DataSet = new UserRoleDataSet();

            if (File.Exists(DatabaseFileName))
            {
                // Load the existing database file.
                this.DataSet.ReadXml(DatabaseFileName);
                this.DataSet.AcceptChanges();
            }
            else
            {
                // Create the demo data.
                this.CreateDemoData();
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static DatabaseContext Instance
        {
            get
            {
                return instance ?? (instance = new DatabaseContext());
            }
        }

        /// <summary>
        /// Gets the data set.
        /// </summary>
        public UserRoleDataSet DataSet { get; private set; }

        public void Save()
        {
            this.DataSet.WriteXml(DatabaseFileName);
            this.DataSet.AcceptChanges();
        }

        private void CreateDemoData()
        {
            var user = this.AddUser("Albert", "Einstein");
            this.AddUser("Isaac", "Newton");
            this.AddUser("Stephen", "Hawking");
            this.AddUser("Richard", "Feynman");
            this.AddUser("Max", "Planck");
            this.AddUser("Marie", "Curie");
            this.AddUser("Johannes", "van der Waals");
            this.AddUser("James", "Watt");

            var role = this.AddRole("Administrator");
            this.AddRole("Power User");

            var userRole = this.SetUserRole(user, role);
        }

        private UserRoleDataSet.UserRow AddUser(string firstName, string lastName)
        {
            return this.DataSet.User.AddUserRow(firstName, lastName);
        }

        private UserRoleDataSet.RoleRow AddRole(string name)
        {
            return this.DataSet.Role.AddRoleRow(name);
        }

        private UserRoleDataSet.UserRoleRow SetUserRole(UserRoleDataSet.UserRow user, UserRoleDataSet.RoleRow role)
        {
            return this.DataSet.UserRole.AddUserRoleRow(user, role);
        }
    }
}