namespace Application.Users.Actions
{
    using Application.Helpers;

    using DataModel;

    using SmallApplicationFramework.Wpf.InteractionRequest;

    using ViewModel.Users.Notifications;

    public class DeleteDynamicColumnAction : TriggerActionBase<DeleteDynamicColumnNotification>
    {
        protected override void ExecuteAction()
        {
            var userGridView = this.AssociatedObject as UserGridView;

            if (userGridView != null && this.Notification.Role != null)
            {
                foreach (var userRoleColumn in userGridView.DataGridUsers.Columns)
                {
                    var roleScan = ObjectTag.GetTag(userRoleColumn) as UserRoleDataSet.RoleRow;
                    if (roleScan == this.Notification.Role)
                    {
                        userGridView.DataGridUsers.Columns.Remove(userRoleColumn);
                        break;
                    }
                }
            }
        }
    }
}