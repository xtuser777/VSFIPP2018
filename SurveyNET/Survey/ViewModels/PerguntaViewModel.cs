using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModels
{
    public class PerguntaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Dica { get; set; }
        public char Obrigatoria { get; set; }
        public decimal Ordem { get; set; }
        public short TipoId { get; set; }
        public int QuestionarioId { get; set; }
        public List<RespostaViewModel> Respostas { get; set; }

        public Object GetPergunta()
        {
            List<Resposta> respostas = new List<Resposta>();
            foreach(RespostaViewModel rvm in this.Respostas)
            {
                respostas.Add(rvm.GetResposta() as Resposta);
            }

            return new Pergunta()
            {
                Id = this.Id,
                Titulo = this.Titulo,
                Descricao = this.Descricao,
                Dica = this.Dica,
                Obrigatoria = this.Obrigatoria,
                Ordem = this.Ordem,
                TipoId = this.TipoId,
                QuestionarioId = this.QuestionarioId,
                Respostas = respostas
            };
        }
    }
}
