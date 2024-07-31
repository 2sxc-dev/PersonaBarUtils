namespace ToSic.Sxc.PersonaBar.Utils
{
    using Dnn.PersonaBar.Library.Containers;
    using DotNetNuke.Abstractions;
    using System;
    using System.Web;

    public class PersonaBarManager : PersonaBarContainer
    {
        private const string CookieKey = "HidePersonaBar";

        public PersonaBarManager(INavigationManager navigationManager) : base(navigationManager)
        { }

        /// <inheritdoc/>
        public override bool Visible => !HidePersonaBar();

        public void Hide() => SetPermanentCookie();

        public void Show() => RemoveCookie();


        private static bool HidePersonaBar()
        {
            // Retrieve the cookie from the request
            var cookie = HttpContext.Current?.Request.Cookies[CookieKey]?.Value;

            return bool.TryParse(cookie, out var result) && result;
        }

        private static void SetPermanentCookie()
        {
            // Create the cookie
            var cookie = new HttpCookie(CookieKey, "true");

            // Set the cookie expiration date
            cookie.Expires = DateTime.Now.AddYears(10);

            // Add the cookie to the response
            HttpContext.Current?.Response?.Cookies.Add(cookie);
        }

        private static void RemoveCookie()
        {
            // Retrieve the cookie
            var cookie = HttpContext.Current.Request.Cookies[CookieKey];
            if (cookie == null) return;

            cookie.Value = "false";
            
            // Set the cookie's expiration date to a past date
            cookie.Expires = DateTime.Now.AddDays(-1);

            // Update the cookie in the response
            HttpContext.Current?.Response.Cookies.Add(cookie);
        }
    }
}
