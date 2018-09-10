using SurveyWeb.Filters;
using SurveyWeb.Models;
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
            //ViewBag.List = QuestionarioDAO.Buscar(txtSearch);
            return View("Index");
        }

        [ValidarAcesso]
        [HttpPost]
        public ActionResult AlterarQuestionario(string txtTitulo, string txtDtInicio, string txtDtFim, string txtFeedback, string txtGuid)
        {
            /*Questionario q = new Questionario(
                txtTitulo,
                DateTime.Parse(txtDtInicio),
                DateTime.Parse(txtDtFim),
                txtFeedback,
                txtGuid);
            if(QuestionarioDAO.Atualiza(q))
            {
                ViewBag.Msg = "Questionário alterado com sucesso.";
            }
            else
            {
                ViewBag.Msg = "Erro ao alterar  questionário.";
            }*/
            return null;
        }

        [ValidarAcesso]
        [HttpPost]
        public ActionResult ExcluirQuestionario(int id)
        {
            /*
             * if(QuestionarioDAO.exclui(id))
             * {
             *     ViewBag.Msg = "Questionário excluído com sucesso.";
             * }
             * else
             * {
             *     ViewBag.Msg = "Erro ao excluir o questionário selecionado.";
             * }
             */
            return View("Index");
        }
    }
}