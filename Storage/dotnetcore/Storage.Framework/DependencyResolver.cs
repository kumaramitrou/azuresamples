using Microsoft.Extensions.DependencyInjection;

namespace Storage.Framework
{
    public static class DependencyResolver
    {
        public static void Register(IServiceCollection service)
        {
            service.AddTransient<IBlobStorage, BlobStorage>();
        }
    }
}
