using System;
using System.Web;

namespace ToSic.Sxc.PersonaBar.Utils
{
    /// <summary>
    /// Special service to manage the visibility of the PersonaBar.
    /// 
    /// It basically just sets/reads the cookie for this setting.
    /// 
    /// For the setting to apply to DNN, the <see cref="PersonaBarContainerAdvanced"/> must be registered in the DI container.
    /// </summary>
    public class PersonaBarManager
    {
        public const string CookieKey = "HidePersonaBar";

        /// <summary>
        /// Determines if visibility is overriden by a cookie.
        /// </summary>
        public bool Visible => _visible ?? (_visible = !IsHidden()).Value;
        private bool? _visible;

        /// <summary>
        /// Hides the PersonaBar.
        /// </summary>
        public void Hide() => SetHidden();

        /// <summary>
        /// Shows the PersonaBar.
        /// </summary>
        public void Show() => RemoveSetting();

        /// <summary>
        /// Toggle the visibility of the PersonaBar, and return the current visibility state.
        /// </summary>
        public bool Toggle()
        {
            if (Visible)
            {
                Hide();
                return false;
            }
            else
            {
                Show();
                return true;
            }
        }





        internal static bool IsHidden()
        {
            // Retrieve the cookie from the request
            var cookie = HttpContext.Current?.Request.Cookies[CookieKey]?.Value;
            return bool.TryParse(cookie, out var result) && result;
        }


        private static void SetHidden()
        {
            // Create the cookie
            var cookie = new HttpCookie(CookieKey, "true")
            {
                // Set the cookie expiration date
                Expires = DateTime.Now.AddYears(10)
            };

            // Add the cookie to the response
            HttpContext.Current?.Response?.Cookies.Add(cookie);
        }

        private static void RemoveSetting()
        {
            // Retrieve the cookie
            var cookie = HttpContext.Current.Request.Cookies[CookieKey];
            if (cookie == null) return;

            cookie.Value = "false";

            // Set the cookie's expiration date to a past date
            cookie.Expires = DateTime.Now.AddDays(-1);

            // Update the cookie in the response
            HttpContext.Current?.Response.Cookies.Set(cookie);
        }
    }
}
