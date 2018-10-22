using Survey.Models;
using Survey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    public class QuestionarioController
    {
        public int Gravar(QuestionarioViewModel q)
        {
            List<Pergunta> perguntas = new List<Pergunta>();
            foreach (PerguntaViewModel pvm in q.Perguntas)
            {
                perguntas.Add(pvm.GetPergunta() as Pergunta);
            }

            Questionario questionario = new Questionario()
            {
                Id = q.Id,
                Nome = q.Nome,
                Inicio = q.Inicio,
                Fim = q.Fim,
                MsgFeedback = q.MsgFeedback,
                Guid = q.Guid,
                Usuario = new Usuario()
                {
                    Id = q.Usuario.Id,
                    Nome = q.Usuario.Nome,
                    Email = q.Usuario.Email,
                    Senha = q.Usuario.Senha,
                    DataCadastro = q.Usuario.DataCadastro,
                    DataFim = q.Usuario.DataFim,
                    Questionarios = null
                },
                UsuarioId = q.UsuarioId,
                Perguntas = perguntas
            };

            return questionario.Gravar();
        }

        public List<QuestionarioViewModel> ObterPorUsuario(int id)
        {
            var dados = new Questionario().ObterPorUsuario(id);
            if (dados != null && dados.Count > 0)
                return (from d in dados
                        select new QuestionarioViewModel()
                        {
                            Id = d.Id,
                            Nome = d.Nome,
                            Inicio = d.Inicio,
                            Fim = d.Fim,
                            MsgFeedback = d.MsgFeedback,
                            Guid = d.Guid,
                            UsuarioId = d.UsuarioId,
                            Perguntas = null,
                            Usuario = null
                        }).ToList();
            else
                return null;
        }

        public List<QuestionarioViewModel> ObterPorId(int userId, int id)
        {
            var dados = new Questionario().ObterPorId(userId, id);
            if (dados != null && dados.Count > 0)
            {
                return (
                    from d in dados
                    select new QuestionarioViewModel()
                    {
                        Id = d.Id,
                        Nome = d.Nome,
                        Inicio = d.Inicio,
                        Fim = d.Fim,
                        MsgFeedback = d.MsgFeedback,
                        Guid = d.Guid,
                        UsuarioId = d.UsuarioId,
                        Perguntas = null,
                        Usuario = null
                    }
                ).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<QuestionarioViewModel> ObterPorPalavraChave(int userId, string chave)
        {
            var dados = new Questionario().ObterPorPalavraChave(userId, chave);
            if (dados != null && dados.Count > 0)
            {
                return (
                    from d in dados
                    select new QuestionarioViewModel()
                    {
                        Id = d.Id,
                        Nome = d.Nome,
                        Inicio = d.Inicio,
                        Fim = d.Fim,
                        MsgFeedback = d.MsgFeedback,
                        Guid = d.Guid,
                        UsuarioId = d.UsuarioId,
                        Perguntas = null,
                        Usuario = null
                    }
                ).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
