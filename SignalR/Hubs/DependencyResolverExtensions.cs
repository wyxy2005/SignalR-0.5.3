namespace SignalR.Hubs
{
    public static class DependencyResolverExtensions
    {
        public static IDependencyResolver UseDynamicHubs(this IDependencyResolver resolver, params string[] allowedHubs)
        {
            var dynamicProvider = new DynamicHubDescriptorProvider(allowedHubs);
            resolver.Register(typeof(IHubDescriptorProvider), () => dynamicProvider);
            return resolver;
        }
    }
}
