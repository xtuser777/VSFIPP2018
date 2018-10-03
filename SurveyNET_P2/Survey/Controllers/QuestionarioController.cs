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
            if(dados != null && dados.Count > 0)
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
