using SurveyWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyWeb.Controllers
{
    public class PerguntasController : Controller
    {
        [ValidarAcesso]
        public ActionResult Index()
        {
            return View();
        }
    }
}