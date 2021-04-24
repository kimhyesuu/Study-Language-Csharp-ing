namespace SmallApplicationFramework.InteractionRequest
{
    using System;

    public class InteractionRequest<T> : IInteractionRequest
        where T : Notification
    {
        /// <summary>
        /// The raised.
        /// </summary>
        public event EventHandler<InteractionRequestedEventArgs> Raised;

        /// <summary>
        /// Raises the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Raise(T context)
        {
            this.Raise(context, c => { });
        }

        /// <summary>
        /// Raises the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="callback">The callback.</param>
        public void Raise(T context, Action<T> callback)
        {
            EventHandler<InteractionRequestedEventArgs> handler = this.Raised;
            if (handler != null)
            {
                handler(this, new InteractionRequestedEventArgs(context, () => callback(context)));
            }
        }
    }
}