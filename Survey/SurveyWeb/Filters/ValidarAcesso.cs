using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyWeb.Filters
{
    public class ValidarAcesso : FilterAttribute, IActionFilter
    {
        private DateTime inicio;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int time = DateTime.Now.Subtract(inicio).Milliseconds;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            inicio = DateTime.Now;

            HttpCookie ck = filterContext.HttpContext.Request.Cookies["token"];
            if (ck == null || ck.Values["nivel"] != "A")
                filterContext.Result = new RedirectResult("/Home/Logout");
        }
    }
}