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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            if(Request.Cookies["token"] != null)
            {
                HttpCookie ck = Request.Cookies["token"];
                ck.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(ck);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult Validar(string txtEmail, string txtSenha)
        {
            if(txtEmail != "usuario@email.com.br" || txtSenha != "123456")
            {
                ViewData["Erros"] = "Um ou mais campos incorretos";
                return View("Login");
            }
            else
            {
                CriaCookie(txtEmail);
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpPost]
        public ActionResult ValidarNovoUsuario(string txtEmailNovo, string txtNomeNovo, string txtSenhaNovo, string txtSenhaNovo2)
        {
            string erros = "";

            if (txtEmailNovo == "usuario@email.com.br")
            {
                erros += ". Usuário já cadastrado.";
                ViewBag.ErrsNewUsr = erros;
                return View("Login");
            }
            else
            {
                //Gravar no banco
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult ValidarRecuperacao(string txtEmailRecuperar)
        {
            if(txtEmailRecuperar != "usuario@email.com.br")
            {
                ViewBag.ErrValid = ". Email não cadastrado.";
                return View("Login");
            }
            else
            {
                //página de recuperação de senha
                return View("Login");
            }
        }

        private void CriaCookie(string user)
        {
            HttpCookie cookie = Request.Cookies["token"];
            if(cookie == null)
            {
                cookie = new HttpCookie("token");
                cookie.Values.Add("user", user);
                cookie.Values.Add("nivel", "A");
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);
            }
        }
    }
}