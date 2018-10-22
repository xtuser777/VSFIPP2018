using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModels
{
    public class AlternativaViewModel
    {
        public int Id { get; set; }
        public string Opcao { get; set; }
        public short Ordem { get; set; }
        public int PerguntaId { get; set; }
        public TipoPerguntaViewModel TipoPergunta { get; set; }
        public List<RespostaViewModel> Respostas { get; set; }
        public PerguntaViewModel Pergunta { get; set; }

        public Object GetAlternativa()
        {
            List<Resposta> respostas = new List<Resposta>();
            foreach(RespostaViewModel rvm in this.Respostas)
            {
                respostas.Add(rvm.GetResposta() as Resposta);
            }

            return new Alternativa()
            {
                Id = this.Id,
                Opcao = this.Opcao,
                Ordem = this.Ordem,
                PerguntaId = this.PerguntaId,
                TipoPergunta = this.TipoPergunta.GetTipoPergunta() as TipoPergunta,
                Respostas = respostas,
                Pergunta = this.Pergunta.GetPergunta() as Pergunta
            };
        }
    }
}
