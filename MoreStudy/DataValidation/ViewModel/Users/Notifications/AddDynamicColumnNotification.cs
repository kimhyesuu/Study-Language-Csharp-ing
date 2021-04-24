namespace ViewModel.Users.Notifications
{
    using DataModel;

    using SmallApplicationFramework.InteractionRequest;

    public class AddDynamicColumnNotification : Notification
    {
        public UserRoleDataSet.RoleRow Role { get; set; }
    }
}