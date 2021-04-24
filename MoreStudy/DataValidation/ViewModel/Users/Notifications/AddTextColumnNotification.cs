namespace ViewModel.Users.Notifications
{
    using SmallApplicationFramework.InteractionRequest;

    public class AddTextColumnNotification : Notification
    {
        public string Header { get; set; }

        public string Binding { get; set; }
    }
}