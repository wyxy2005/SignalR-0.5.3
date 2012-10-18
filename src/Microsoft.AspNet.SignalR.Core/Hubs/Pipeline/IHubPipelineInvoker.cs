using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNet.SignalR.Hubs
{
    /// <summary>
    /// Implementations of this interface are responsible for executing operation required to complete various stages
    /// hub processing such as connecting, reconnecting, disconnecting, invoking server-side hub methods, invoking
    /// client-side hub methods, authorizing hub clients and rejoining hub groups.
    /// </summary>
    public interface IHubPipelineInvoker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<object> Invoke(IHubIncomingInvokerContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task Send(IHubOutgoingInvokerContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hub"></param>
        /// <returns></returns>
        Task Connect(IHub hub);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hub"></param>
        /// <returns></returns>
        Task Reconnect(IHub hub);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hub"></param>
        /// <returns></returns>
        Task Disconnect(IHub hub);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hubDescriptor"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        bool AuthorizeConnect(HubDescriptor hubDescriptor, IRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hubDescriptor"></param>
        /// <param name="request"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        IEnumerable<string> RejoiningGroups(HubDescriptor hubDescriptor, IRequest request, IEnumerable<string> groups);
    }
}
