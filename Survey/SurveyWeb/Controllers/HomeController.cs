using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validar(string txtEmail, string txtSenha)
        {
            if(txtEmail != "usuario@email.com.br" || txtSenha != "123")
            {
                ViewBag.Erro = "Um ou mais campos incorretos";
                return View("Index");
            }
            else
            {
                CriaCookie("login");
                return RedirectToAction("Dashboard", "Home");
            }
        }

        private void CriaCookie(string nome)
        {
            HttpCookie cookie = Request.Cookies[nome];
            if(cookie == null)
            {
                cookie = new HttpCookie(nome);
                cookie.Values.Add("logado", "true");
                cookie.Expires = DateTime.Now.AddHours(1);
                cookie.HttpOnly = true;
                Response.AppendCookie(cookie);
            }
        }

        public bool Logado(string nome)
        {
            bool active = false;
            HttpCookie cookie = GetCookie(nome);
            if(cookie != null)
            {
                string valor = cookie.Value.ToString();
                if (valor == "logado=true")
                    active = true;
            }
            return active;
        }

        private HttpCookie GetCookie(string nome)
        {
            try
            {
                return Request.Cookies[nome];
            }
            catch
            {
                return null;
            }
        }
    }
}