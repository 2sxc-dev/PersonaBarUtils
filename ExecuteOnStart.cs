using DotNetNuke.Web.Api;

namespace ToSic.Sxc.PersonaBar.Utils
{
    public class ExecuteOnStart : IServiceRouteMapper
    {
        private readonly PersonaBarManager _personaBarManager;

        public ExecuteOnStart(PersonaBarManager personaBarManager)
        {
            // Just need an instance to init PersonaBar visibility from cookie on dnn start
            _personaBarManager = personaBarManager;
        }


        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            // We don't need any routes, and this code is doing nothing.
            var _ = _personaBarManager.HidePersonaBar();
        }
    }
}
