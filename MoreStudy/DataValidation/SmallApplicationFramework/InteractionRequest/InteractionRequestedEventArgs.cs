namespace SmallApplicationFramework.InteractionRequest
{
    using System;

    public class InteractionRequestedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionRequestedEventArgs"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="callback">The callback.</param>
        public InteractionRequestedEventArgs(Notification context, Action callback)
        {
            this.Context = context;
            this.Callback = callback;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public Notification Context { get; private set; }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        public Action Callback { get; private set; }
    }
}