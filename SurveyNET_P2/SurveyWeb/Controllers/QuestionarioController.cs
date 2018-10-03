using SurveyWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cl = Survey.Controllers;
using Survey.ViewModels;

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
            return Json(dados,JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObterPorId(int userId, int id)
        {
            var dados = new cl.QuestionarioController().ObterPorId(userId, id);
            return Json(dados, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObterPorPalavraChave(int userId, string chave)
        {
            var dados = new cl.QuestionarioController().ObterPorPalavraChave(userId, chave);
            return Json(dados, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Gravar(string Titulo, string DataInicio, string DataFim, string Feedback, string Guid)
        {
            if(Titulo != "" && Feedback != "" && Guid != "" && DataInicio != "" && DataFim != "")
            {
                var dataInicio = DateTime.Parse(DataInicio);
                var dataFim = DateTime.Parse(DataFim);
                cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
                ctlQuestionario.
            }
        }

        //Definir a rota para mapear a URL /PDF/Exportar/_NOME_DO_PARAMETRO_
        public ActionResult Exportar(string palavraChave = "")
        {
            return View("Index");
            //return File(...);
        }
    }
}