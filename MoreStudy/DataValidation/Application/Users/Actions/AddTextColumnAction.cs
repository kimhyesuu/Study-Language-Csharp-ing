namespace Application.Users.Actions
{
    using System.Windows.Controls;
    using System.Windows.Data;

    using SmallApplicationFramework.Wpf.InteractionRequest;

    using ViewModel.Users.Notifications;

    public class AddTextColumnAction : TriggerActionBase<AddTextColumnNotification>
    {
        protected override void ExecuteAction()
        {
            var userGridView = this.AssociatedObject as UserGridView;
            if (userGridView != null)
            {
                var binding = new Binding(this.Notification.Binding);
                binding.ValidatesOnDataErrors = true;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;

                userGridView.DataGridUsers.Columns.Add(
                    new DataGridTextColumn
                        {
                            Header = this.Notification.Header,
                            Binding = binding
                        });
            }
        }
    }
}