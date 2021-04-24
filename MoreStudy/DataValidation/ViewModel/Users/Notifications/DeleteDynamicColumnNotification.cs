namespace ViewModel.Users.Notifications
{
    using DataModel;

    using SmallApplicationFramework.InteractionRequest;

    public class DeleteDynamicColumnNotification : Notification
    {
        public UserRoleDataSet.RoleRow Role { get; set; }
    }
}