using SurveyWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyWeb.Controllers
{
    public class QuestionariosController : Controller
    {
        [ValidarAcesso]
        public ActionResult Index()
        {
            return View();
        }

        [ValidarAcesso]
        [HttpPost]
        public ActionResult Buscar(string txtSearch)
        {
            return null;
        }

        [ValidarAcesso]
        [HttpPost]
        public ActionResult AlterarQuestionario(string txtTitulo, string txtDtInicio, string txtDtFim, string txtFeedback, string txtGuid)
        {
            return null;
        }

        [ValidarAcesso]
        [HttpPost]
        public ActionResult ExcluirQuestionario(int id)
        {
            return null;
        }
    }
}