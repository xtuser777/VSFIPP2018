using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Survey.ViewModels;
using cl = Survey.Controllers;

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
        public ActionResult Validar(string Email, string Senha)
        {
            if(Email != "" && Senha != "")
            {
                cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                var usuario = ctlUsuario.Autenticar(Email, Senha);
                if(usuario != null)
                {
                    HttpCookie ck = new HttpCookie("token");
                    ck.Values.Add("idUsuario", usuario.Id.ToString());
                    if(usuario.Nome.Length > 15)
                    {
                        usuario.Nome = usuario.Nome.Substring(0, 15);
                    }
                    ck.Values.Add("nomeUsuario", usuario.Nome);
                    Response.Cookies.Add(ck);

                    return Json("");
                }
                else
                {
                    return Json("O usuário e/ou a senha informada não conferem.");
                }
            }
            else
            {
                return Json("Por favor, informe um usuário e uma senha para acesso.");
            }
        }

        [HttpPost]
        public ActionResult Gravar(string Email, string Nome, string Senha)
        {
            if(Email != "" && Nome.Length > 2 && Senha.Length > 0)
            {
                cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                UsuarioViewModel usuario = new UsuarioViewModel()
                {
                    Id = 0,
                    Nome = Nome,
                    Senha = Senha,
                    Email = Email,
                    DataCadastro = DateTime.Now,
                    DataFim = null
                };
                if(ctlUsuario.Gravar(usuario) > 0)
                {
                    return Json("");
                }
                else
                {
                    return Json("Erro ao gravar o usuário.");
                }
            }
            else
            {
                return Json("Por favor, informe todos os dados para criar um novo usuário.");
            }
        }

        public ActionResult Logout()
        {
            HttpCookie ck = Request.Cookies["token"];
            if(ck != null)
            {
                ck.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(ck);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}