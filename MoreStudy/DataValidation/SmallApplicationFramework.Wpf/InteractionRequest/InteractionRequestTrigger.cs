namespace SmallApplicationFramework.Wpf.InteractionRequest
{
    using System.Windows.Interactivity;

    public class InteractionRequestTrigger : EventTrigger
    {
        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        /// <returns>The event name.</returns>
        protected override string GetEventName()
        {
            return "Raised";
        }
    }
}