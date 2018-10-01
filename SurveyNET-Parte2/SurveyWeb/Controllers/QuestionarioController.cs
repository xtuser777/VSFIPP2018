using SurveyWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Survey.ViewModels;
using cl = Survey.Controllers;

namespace SurveyWeb.Controllers
{
    [ValidarAcessoFilter]
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
            return Json(dados, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Exportar(string palavraChave = "")
        {
            return View("Index");
        }
}