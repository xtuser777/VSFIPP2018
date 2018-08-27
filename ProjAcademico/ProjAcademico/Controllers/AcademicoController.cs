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
                return RedirectToAction("Dashboard", "Academico");
            }
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult GerenciarCursos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GravarCurso()
        {
            return null;
        }
    }
}