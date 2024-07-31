using DotNetNuke.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ToSic.Sxc.PersonaBar.Utils
{
    public class Startup : IDnnStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PersonaBarManager>();
        }
    }
}