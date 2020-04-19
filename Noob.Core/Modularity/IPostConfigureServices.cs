using Microsoft.Extensions.DependencyInjection;

namespace Noob.Modularity
{
    public interface IPostConfigureServices
    {
        void PostConfigureServices(ServiceConfigurationContext context);
    }
}