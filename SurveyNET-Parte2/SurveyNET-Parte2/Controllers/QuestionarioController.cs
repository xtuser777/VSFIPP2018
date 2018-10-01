using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyNET_Parte2.Filters;

namespace SurveyNET_Parte2.Controllers
{
    public class QuestionarioController : Controller
    {
        // GET: Questionario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObterPorUsuario(int id)
        {
            var dados = new cl.QuestionarioController().ObterPorUsuario(id);
        }
    }
}