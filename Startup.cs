using Dnn.PersonaBar.Library.Containers;
using DotNetNuke.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ToSic.Sxc.PersonaBar.Utils
{
    public class Startup : IDnnStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Replace the original dnn PersonaBarContainer service with a new implementation
            services.Replace(new ServiceDescriptor(
                typeof(IPersonaBarContainer),
                typeof(PersonaBarManager),
                ServiceLifetime.Singleton));
        }
    }
}