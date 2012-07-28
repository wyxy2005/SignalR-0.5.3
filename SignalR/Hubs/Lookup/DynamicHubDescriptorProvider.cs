using System;
using System.Collections.Generic;
using System.Linq;

namespace SignalR.Hubs
{
    /// <summary>
    /// Allows dynamic hub discovery
    /// </summary>
    public class DynamicHubDescriptorProvider : IHubDescriptorProvider
    {
        private readonly Dictionary<string, HubDescriptor> _allowedHubs;

        public DynamicHubDescriptorProvider(params string[] allowedHubs)
        {
            _allowedHubs = allowedHubs.ToDictionary(name => name, 
                                                    name => new HubDescriptor { Name = name }, 
                                                    StringComparer.OrdinalIgnoreCase);
        }

        public IList<HubDescriptor> GetHubs()
        {
            return new List<HubDescriptor>(_allowedHubs.Values);
        }

        /// <summary>
        /// Returns a hub descriptor for the spec
        /// </summary>
        /// <param name="hubName"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public bool TryGetHub(string hubName, out HubDescriptor descriptor)
        {
            if (_allowedHubs.Count == 0)
            {
                descriptor = new HubDescriptor { Name = hubName };
                return true;
            }

            return _allowedHubs.TryGetValue(hubName, out descriptor);
        }
    }
}
