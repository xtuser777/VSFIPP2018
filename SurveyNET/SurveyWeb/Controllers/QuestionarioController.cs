using Survey.ViewModels;
using SurveyWeb.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        [ValidarAcessoFilter]
        public ActionResult ObterPorUsuario(int id)
        {
            var dados = new cl.QuestionarioController().ObterPorUsuario(id);
            return Json(dados, JsonRequestBehavior.AllowGet);
        }

        [ValidarAcessoFilter]
        public ActionResult ObterPorId(int Id, int IdUsuario)
        {
            var dados = new cl.QuestionarioController().ObterPorId(IdUsuario, Id);
            return dados == null ? Json("") : Json(dados);
        }

        [ValidarAcessoFilter]
        public ActionResult ObterPorPalavraChave(string Chave, int IdUsuario)
        {
            var dados = new cl.QuestionarioController().ObterPorPalavraChave(IdUsuario, Chave);
            return dados == null ? Json("") : Json(dados);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void Resize(Stream img, int novaLargura, string nomeArquivo, out string base64)
        {
            // Cria um objeto de imagem baseado no stream do arquivo enviado
            Bitmap originalBMP = new Bitmap(img);

            // Calcula a nova dimensao da imagem
            int origWidth = originalBMP.Width;
            int origHeight = originalBMP.Height;
            double sngRatio = (double)novaLargura / origWidth;
            int newWidth = novaLargura;
            int newHeight = Convert.ToInt32(origHeight * sngRatio);

            // Cria uma nova imagem a partir da imagem original
            Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

            // Grava a nova imagem no servidor
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            // Converter imagem em base64 para gravar como string no banco de dados
            MemoryStream ms = new MemoryStream();
            newBMP.Save(ms, ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();
            base64 = Convert.ToBase64String(imageBytes);

            // Retira os objetos da memória
            originalBMP.Dispose();
            newBMP.Dispose();
        }

        public void ConverterImagem(out string erro64, out string imagem64)
        {
            string base64 = "";
            string erros = "";

            try
            {
                var extensoesPermitidas = new[] { ".jpg", ".png", ".gif" };
                
                //Recepcionando arquivo
                var arquivo = Request.Files[0];
                if (arquivo != null && arquivo.ContentLength > 0 && arquivo.ContentLength <= 1048576)
                {
                    string extensaoArquivo =
                        Path.GetExtension(arquivo.FileName).ToLower();

                    //tipoArquivo = arquivo.ContentType; mime type
                    if (extensoesPermitidas.Contains(extensaoArquivo))
                    {
                        //Definindo o nome e caminho para gravação
                        var nomeArquivo = string.Format("{0}", arquivo.FileName);
                        var caminho = Server.MapPath("~/Content/Imagens");
                        caminho = Path.Combine(caminho, nomeArquivo);

                        
                        Resize(arquivo.InputStream, 250, caminho, out base64);
                    }
                    else
                    {
                        erros += "Formato inválido de arquivo";
                    }
                }
                else
                {
                    erros += "Tamanho inválido de arquivo";
                }
                erro64 = erros;
            }
            catch (Exception ex)
            {
                erro64 = ex.Message;
            }
            imagem64 = base64;
        }

        [HttpPost]
        [ValidarAcessoFilter]
        public ActionResult Gravar(FormCollection form)
        {
            string Nome = form["Nome"];
            string Guid = form["Guid"];
            string Inicio = form["Inicio"];
            string Fim = form["Fim"];
            string MsgFeedBack = form["FeedBack"];
            string Imagem64 = "";
            string Erro64 = "";

            if (Nome != "" && Guid != "" && Inicio != "" && Fim != "")
            {
                if(Request.Files.Count > 0)
                {
                    ConverterImagem(out Erro64, out Imagem64);
                    if (Erro64.Length == 0)
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
                            Imagem64 = Imagem64,
                            Usuario = usuario,
                            UsuarioId = usuario.Id
                        });

                        if (res > 0)
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
                        return Json(Erro64);
                    }
                }
                else
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
                        Imagem64 = Imagem64,
                        Usuario = usuario,
                        UsuarioId = usuario.Id
                    });

                    if (res > 0)
                    {
                        return Json("");
                    }
                    else
                    {
                        return Json("Erro ao gravar o questionário");
                    }
                }
            }
            else
            {
                return Json("Dados de entrada inválidos.");
            }
        }

        [HttpPost]
        [ValidarAcessoFilter]
        public ActionResult Alterar(FormCollection form)
        {
            string Id = form["Id"];
            string Nome = form["Nome"];
            string Inicio = form["Inicio"];
            string Fim = form["Fim"];
            string FeedBack = form["FeedBack"];
            string Guid = form["Guid"];
            string Imagem64 = "";
            string Erro64 = "";

            if (Nome != "" && Guid != "" && Inicio != "" && Fim != "")
            {
                if(Request.Files.Count > 0)
                {
                    ConverterImagem(out Erro64, out Imagem64);
                    if(Erro64.Length == 0)
                    {
                        cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
                        cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                        var usuario = ctlUsuario.ObterPorId(int.Parse(Request.Cookies["token"].Values["idUsuario"].ToString()));

                        var res = ctlQuestionario.Alterar(new QuestionarioViewModel()
                        {
                            Id = Convert.ToInt32(Id),
                            Nome = Nome,
                            Inicio = DateTime.Parse(Inicio),
                            Fim = DateTime.Parse(Fim),
                            MsgFeedback = FeedBack,
                            Guid = Guid,
                            Imagem64 = Imagem64,
                            Usuario = usuario,
                            UsuarioId = usuario.Id
                        });

                        if (res > 0)
                        {
                            return Json("");
                        }
                        else
                        {
                            return Json("Erro ao alterar o questionário");
                        }
                    }
                    else
                    {
                        return Json(Erro64);
                    }
                }
                else
                {
                    cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
                    cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                    var usuario = ctlUsuario.ObterPorId(int.Parse(Request.Cookies["token"].Values["idUsuario"].ToString()));

                    var res = ctlQuestionario.Alterar(new QuestionarioViewModel()
                    {
                        Id = Convert.ToInt32(Id),
                        Nome = Nome,
                        Inicio = DateTime.Parse(Inicio),
                        Fim = DateTime.Parse(Fim),
                        MsgFeedback = FeedBack,
                        Guid = Guid,
                        Imagem64 = Imagem64,
                        Usuario = usuario,
                        UsuarioId = usuario.Id
                    });

                    if (res > 0)
                    {
                        return Json("");
                    }
                    else
                    {
                        return Json("Erro ao alterar o questionário");
                    }
                }
                
            }
            else
            {
                return Json("Dados de entrada inválidos.");
            }
        }

        [HttpPost]
        [ValidarAcessoFilter]
        public ActionResult Excluir(int Id)
        {
            cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
            if (ctlQuestionario.Excluir(Id) > 0)
                return Json("");
            else
                return Json("Não foi possível excluir o registro selecionado.");
        }

        [ValidarAcessoFilter]
        //Definir a rota para mapear a URL /PDF/Exportar/_NOME_DO_PARAMETRO_
        public ActionResult Exportar(string palavraChave = "")
        {
            return View("Index");
            //return File(...);
        }
    }
}