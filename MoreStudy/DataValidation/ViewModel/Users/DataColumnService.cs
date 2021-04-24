namespace ViewModel.Users
{
    using SmallApplicationFramework.InteractionRequest;

    using ViewModel.Users.Notifications;

    public class DataColumnService
    {
        private static DataColumnService instance;

        private DataColumnService()
        {
            this.AddTextColumnRequest = new InteractionRequest<AddTextColumnNotification>();
            this.AddDynamicColumnRequest = new InteractionRequest<AddDynamicColumnNotification>();
            this.ChangeDynamicColumnRequest = new InteractionRequest<ChangeDynamicColumnNotification>();
            this.DeleteDynamicColumnRequest = new InteractionRequest<DeleteDynamicColumnNotification>();
        }

        public static DataColumnService Instance
        {
            get
            {
                return instance ?? (instance = new DataColumnService());
            }
        }

        public InteractionRequest<AddTextColumnNotification> AddTextColumnRequest { get; private set; }

        public InteractionRequest<AddDynamicColumnNotification> AddDynamicColumnRequest { get; private set; }

        public InteractionRequest<ChangeDynamicColumnNotification> ChangeDynamicColumnRequest { get; private set; }

        public InteractionRequest<DeleteDynamicColumnNotification> DeleteDynamicColumnRequest { get; private set; }
    }
}