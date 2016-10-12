using System.Web.Mvc;

namespace CCS.Areas.Wires
{
    public class WiresAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Wires";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Wires_default",
                "Wires/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}