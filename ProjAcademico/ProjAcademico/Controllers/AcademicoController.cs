using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjAcademico.Controllers
{
    public class AcademicoController : Controller
    {
        // GET: Academico
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticacao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidaAutenticacao(string txtLogin, string txtPwd)
        {
            int cod = 0;
            int.TryParse(txtLogin, out cod);

            if(cod <= 0 || txtLogin.Length < 1 || cod != 1000|| txtPwd != "123")
            {
                ViewBag.Erro = "Um ou mais campos incorretos.";
                return View("Autenticacao");
            }
            else
            {
                GravandoDadosCookie("logado");
                return RedirectToAction("Dashboard", "Academico");
            }
        }

        public ActionResult Dashboard()
        {
            if (VerificarCookie("logado"))
                return View();
            else
                return RedirectToAction("Autenticacao", "Academico");
        }

        public ActionResult GerenciarCursos()
        {
            if (VerificarCookie("logado"))
                return View();
            else
                return RedirectToAction("Autenticacao", "Academico");
        }

        [HttpPost]
        public ActionResult GravarCurso(string txtId, string txtNome, string selSituacao, string selCategoria)
        {
            return null;
        }

        private void GravandoDadosCookie(string nomeCookie)
        {
            // Verificando se já existe o cookie na máquina do usuário
            HttpCookie cookie = Request.Cookies[nomeCookie];
            if (cookie == null)
            {
                // Criando a Instância do cookie
                cookie = new HttpCookie(nomeCookie);
                //Adicionando a propriedade "Nome" no cookie
                cookie.Values.Add("activeUser", "true");
                //colocando o cookie para expirar em uma hora
                cookie.Expires = DateTime.Now.AddHours(1);
                // Definindo a segurança do nosso cookie
                cookie.HttpOnly = true;
                // Registrando cookie
                this.Response.AppendCookie(cookie);

            }
        }

        /*
         * Método 02
         *  Método responsável por obter as propriedades de um cookie caso ele exista
         */
        public bool VerificarCookie(string nomeCookie)
        {
            bool active = false;
            // Obtém a requisição com dos dados do cookie
            HttpCookie cookie = ObterRequisicaoCookie(nomeCookie);
            if (cookie != null)
            {
                // Separa os valores das propriedade
                string valor = cookie.Value.ToString();
                if (valor == "activeUser=true")
                    active = true;
            }
            return active;
        }

        /*
         * Método 03
         * Método responsável por Obter a requisição HttpCookie de um determinado cookie caso ele exista
         */
        private HttpCookie ObterRequisicaoCookie(string nomeCookie)
        {
            try
            {
                // Retornando o cookie caso exista
                return this.Request.Cookies[nomeCookie];
            }
            catch
            {
                // Caso não exista o cookie informado, retorna NULL
                return null;
            }
        }
    }
}