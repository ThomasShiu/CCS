using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CCS
{
    /// <summary>
    /// Joins a first name and a last name together into a single string.
    /// </summary>
    /// <param name="firstName">The first name to join.</param>
    /// <param name="lastName">The last name to join.</param>
    /// <returns>The joined names.</returns>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Portal",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Portal", id = UrlParameter.Optional },
                namespaces: new[] { "CCS.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CCS.Controllers"}
            );
        }
    }
}
