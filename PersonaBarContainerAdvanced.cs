using Dnn.PersonaBar.Library.Containers;
using DotNetNuke.Abstractions;

namespace ToSic.Sxc.PersonaBar.Utils
{
    /// <summary>
    /// Replace the original PersonaBarContainer service with a new implementation
    /// which allows making it invisible by setting a cookie.
    /// 
    /// IMPORTANT: This is a singleton!
    /// </summary>
    public class PersonaBarContainerAdvanced : PersonaBarContainer
    {

        public PersonaBarContainerAdvanced(INavigationManager navigationManager) : base(navigationManager)
        { }

        /// <inheritdoc/>
        public override bool Visible
        {
            get
            {
                // if hidden from base, keep that no matter what the cookie says
                if (!base.Visible)
                    return false;

                // Get visible state from cookie
                // note: we can't cache it to a local variable, because this is a singleton!
                return !PersonaBarManager.IsHidden();
            }
        }
    }
}
