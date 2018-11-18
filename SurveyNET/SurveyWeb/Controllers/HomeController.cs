using Survey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cl = Survey.Controllers;
using System.Net;
using System.Net.Mail;

namespace SurveyWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.Cookies["token"] == null)
                return View();
            else
                return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult Validar(string Email, string Senha)
        {
            if (Email != "" && Senha != "")
            {
                cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                var usuario = ctlUsuario.Autenticar(Email, Senha);
                if (usuario != null)
                {
                    HttpCookie ck = new HttpCookie("token");
                    ck.Values.Add("idUsuario", usuario.Id.ToString());
                    if (usuario.Nome.Length > 15)
                        usuario.Nome = usuario.Nome.Substring(0, 15);
                    ck.Values.Add("nomeUsuario", usuario.Nome);
                    Response.Cookies.Add(ck);

                    return Json("");
                }
                else
                {
                    return Json("O usuário e/ou a senha informados não conferem.");
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
            if (Email != "" && Nome.Length > 2 && Senha.Length > 0)
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
                if (ctlUsuario.Gravar(usuario) > 0)
                    return Json("");
                else
                    return Json("Erro ao gravar o novo usuário.");
            }
            else
            {
                return Json("Por favor, informe todos os dados para criar um novo usuário.");
            }
        }

        [HttpPost]
        public ActionResult RecuperarSenha(string Email)
        {
            if(Email.Length > 5 && Email.Contains("@"))
            {
                cl.UsuarioController ctlUsuario = new cl.UsuarioController();

                string emailFrom = "recovery.surveynet@gmail.com";
                string nomeFrom = "SurveyNET";
                string emailPara = Email;
                string assunto = "Recuperacao de Senha";
                string texto = @"Survey NET\n
                                 Recuperacao de Senha\n
                                 Sua senha é: "+ctlUsuario.ObterPorEmail(Email).Senha;
                return Json(EnviarEmail(emailFrom, nomeFrom, emailPara, assunto, texto));
            }
            else
            {
                return Json("Email inválido");
            }
        }

        public string EnviarEmail(string emailFrom, string nomeFrom, string emailPara, string assunto, string texto)
        {
            //Gerando o objeto da mensagem
            MailMessage msg = new MailMessage();
            //Remetente
            msg.From = new MailAddress(emailFrom, nomeFrom);
            //Destinatários
            msg.To.Add(emailPara);
            //Assunto
            msg.Subject = assunto;
            //Texto a ser enviado
            msg.Body = texto;
            msg.IsBodyHtml = true;

            //Gerando o objeto para envio da mensagem (Exemplo pelo Gmail)
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("recovery.surveynet@gmail.com", "SurveyNET2018");
            try
            {
                client.Send(msg);
                return "Mensagem enviada com sucesso!";
            }
            catch (Exception ex)
            {
                return "Falha: " + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }

        public ActionResult Logout()
        {
            HttpCookie ck = Request.Cookies["token"];
            if (ck != null)
            {
                ck.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(ck);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}