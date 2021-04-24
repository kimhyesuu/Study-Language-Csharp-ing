namespace ViewModel.Users.Notifications
{
    using DataModel;

    using SmallApplicationFramework.InteractionRequest;

    public class ChangeDynamicColumnNotification : Notification
    {
        public UserRoleDataSet.RoleRow Role { get; set; }
    }
}