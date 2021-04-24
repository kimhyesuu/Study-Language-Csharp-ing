namespace ViewModel
{
    using System.Windows.Input;

    using DataModel;

    using ViewModel.Commands;
    using ViewModel.Roles;
    using ViewModel.Users;

    public class MainViewModel
    {
        private readonly DatabaseContext databaseContext;

        public MainViewModel()
        {
            this.SaveCommand = new SaveCommand();
            this.databaseContext = DatabaseContext.Instance;
            this.UserGridViewModel = new UserGridViewModel();
            this.RoleGridViewModel = new RoleGridViewModel();
        }

        public UserGridViewModel UserGridViewModel { get; private set; }

        public RoleGridViewModel RoleGridViewModel { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public void OnLoaded()
        {
            this.UserGridViewModel.InitializeDataHandling(this.databaseContext);
            this.RoleGridViewModel.InitializeDataHandling(this.databaseContext);
        }
    }
}