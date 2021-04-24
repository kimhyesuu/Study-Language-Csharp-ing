namespace SmallApplicationFramework.Wpf.InteractionRequest
{
    using System;
    using System.Windows;
    using System.Windows.Interactivity;

    using SmallApplicationFramework.InteractionRequest;

    public abstract class TriggerActionBase<T> : TriggerAction<FrameworkElement> where T : Notification
    {
        private T notification;

        private Action callback;

        protected T Notification
        {
            get
            {
                return this.notification;
            }
        }

        protected Action Callback
        {
            get
            {
                return this.callback;
            }
        }

        protected override void Invoke(object parameter)
        {
            var interactionRequestedEventArgs = parameter as InteractionRequestedEventArgs;
            if (interactionRequestedEventArgs != null)
            {
                this.notification = interactionRequestedEventArgs.Context as T;
                this.callback = interactionRequestedEventArgs.Callback;
                if (this.notification != null)
                {
                    this.ExecuteAction();
                }
            }
        }

        protected abstract void ExecuteAction();
    }
}