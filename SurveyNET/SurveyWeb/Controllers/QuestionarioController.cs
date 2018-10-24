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

        public ActionResult ObterPorId(int Id, int IdUsuario)
        {
            var dados = new cl.QuestionarioController().ObterPorId(IdUsuario, Id);
            return dados == null ? Json("") : Json(dados);
        }

        public ActionResult ObterPorPalavraChave(string Chave, int IdUsuario)
        {
            var dados = new cl.QuestionarioController().ObterPorPalavraChave(IdUsuario, Chave);
            return dados == null ? Json("") : Json(dados);
        }

        [HttpPost]
        public ActionResult Gravar(string Id, string Nome, string Inicio, string Fim, string MsgFeedBack, string Guid)
        {
            if (Nome != "" && Guid != "" && Inicio != "" && Fim != "")
            {
                var dataInicio = DateTime.Parse(Inicio);
                var dataFim = DateTime.Parse(Fim);
                cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
                cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                var usuario = ctlUsuario.ObterPorId(int.Parse(Request.Cookies["token"].Values["idUsuario"].ToString()));
        
                var res = ctlQuestionario.Gravar(new QuestionarioViewModel()
                {
                    Id = 0,
                    Nome = Nome,
                    Inicio = DateTime.Parse(Inicio),
                    Fim = DateTime.Parse(Fim),
                    MsgFeedback = MsgFeedBack,
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

        [HttpPost]
        public ActionResult Excluir(int Id)
        {
            cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
            if (ctlQuestionario.Excluir(Id) > 0)
                return Json("");
            else
                return Json("Não foi possível excluir o registro selecionado.");
        }

        //Definir a rota para mapear a URL /PDF/Exportar/_NOME_DO_PARAMETRO_
        public ActionResult Exportar(string palavraChave = "")
        {
            return View("Index");
            //return File(...);
        }
    }
}