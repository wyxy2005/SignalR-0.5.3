
namespace Microsoft.AspNet.SignalR.Hubs
{
    /// <summary>
    /// A description of a server-side hub method invocation originating from a client.
    /// </summary>
    public interface IHubIncomingInvokerContext
    {
        /// <summary>
        /// A hub instance that contains the invoked method as a member.
        /// </summary>
        IHub Hub { get; }

        /// <summary>
        /// A description of the method being invoked by the client.
        /// </summary>
        MethodDescriptor MethodDescriptor { get; }

        /// <summary>
        /// The arguments to be passed to the invoked method.
        /// </summary>
        object[] Args { get; }

        /// <summary>
        /// A key-value store that holds arbitrary state associated with the invoking client.
        /// </summary>
        TrackingDictionary State { get; }
    }
}
