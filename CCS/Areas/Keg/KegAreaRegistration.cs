using System.Web.Mvc;

namespace CCS.Areas.Keg
{
    public class KegAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Keg";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Keg_default",
                "Keg/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}