using System.Web.Mvc;

namespace AreasRotas.Areas.LP
{
    public class LPAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LP_default",
                "LP/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}