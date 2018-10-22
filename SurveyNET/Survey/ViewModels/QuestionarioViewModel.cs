using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModels
{
    public class QuestionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string MsgFeedback { get; set; }
        public string Guid { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public List<PerguntaViewModel> Perguntas { get; set; }

        public Object GetQuestionario()
        {
            List<Pergunta> perguntas = new List<Pergunta>();
            foreach(PerguntaViewModel pvm in this.Perguntas)
            {
                perguntas.Add(pvm.GetPergunta() as Pergunta);
            }

            return new Questionario()
            {
                Id = this.Id,
                Nome = this.Nome,
                Inicio = this.Inicio,
                Fim = this.Fim, 
                MsgFeedback = this.MsgFeedback,
                Guid = this.Guid,
                UsuarioId = this.UsuarioId,
                Usuario = this.Usuario.GetUsuario() as Usuario,
                Perguntas = perguntas
            };
        }
    }
}
