namespace SmallApplicationFramework.InteractionRequest
{
    using System;

    public interface IInteractionRequest
    {
        event EventHandler<InteractionRequestedEventArgs> Raised;
    }
}