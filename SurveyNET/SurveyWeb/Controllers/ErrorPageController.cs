using SurveyWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyWeb.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        [ValidarAcessoFilter]
        public ActionResult Index()
        {
            return View();
        }

        [ValidarAcessoFilter]
        public ActionResult Ops(int? id)
        {
            if (id.HasValue)
            {
                switch (id)
                {
                    case 404:
                        return View("Erro404");
                        break;
                    case 500:
                        return View("Erro500");
                        break;
                    case 403:
                        return View("Erro403");
                        break;
                    default:
                        return View("Padrao");
                        break;
                }
            }
            else
            {
                return View("Padrao");
            }
        }
    }
}