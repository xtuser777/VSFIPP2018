using Survey.ViewModels;
using SurveyWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cl = Survey.Controllers;

namespace SurveyWeb.Controllers
{
    public class QuestionarioController : Controller
    {
        // GET: Questionario
        [ValidarAcessoFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObterPorUsuario(int id)
        {
            var dados = new cl.QuestionarioController().ObterPorUsuario(id);
            return Json(dados, JsonRequestBehavior.AllowGet);
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
            if (Titulo != "" && Feedback != "" && Guid != "" && DataInicio != "" && DataFim != "")
            {
                var dataInicio = DateTime.Parse(DataInicio);
                var dataFim = DateTime.Parse(DataFim);
                cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
                cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                var usuario = ctlUsuario.ObterPorId(int.Parse(Request.Cookies["token"].Values["idUsuario"].ToString()));
        
                var res = ctlQuestionario.Gravar(new QuestionarioViewModel()
                {
                    Id = 0,
                    Nome = Titulo,
                    Inicio = DateTime.Parse(DataInicio),
                    Fim = DateTime.Parse(DataFim),
                    MsgFeedback = Feedback,
                    Guid = Guid,
                    Usuario = usuario,
                    UsuarioId = usuario.Id
                });

                if(res > 0)
                {
                    return Json("");
                }
                else
                {
                    return Json("Erro ao gravar o questionário");
                }
            }
            else
            {
                return Json("Dados de entrada inválidos.");
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