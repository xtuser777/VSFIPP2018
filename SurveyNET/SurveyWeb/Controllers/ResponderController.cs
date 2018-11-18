using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cl = Survey.Controllers;
using vm = Survey.ViewModels;

namespace SurveyWeb.Controllers
{
    public class ResponderController : Controller
    {
        // GET: Responder
        public ActionResult Index(string guid)
        {
            cl.QuestionarioController qctl = new cl.QuestionarioController();
            vm.QuestionarioViewModel qvm = qctl.ObterPorGuid(guid);
            if(qvm != null)
            {
                ViewBag.erro = "0";
                ViewBag.survey = qvm;
            }
            else
            {
                ViewBag.erro = "1";
            }
            return View();
        }
    }
}