using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModels
{
    public class RespostaViewModel
    {
        public int Id { get; set; }
        public int PerguntaId { get; set; }
        public int AlternativaId { get; set; }
        public string Texto { get; set; }
        public string TextoCurto { get; set; }
        public decimal Numerica { get; set; }
        public DateTime Data { get; set; }
        public string Token { get; set; }
        public AlternativaViewModel Alternativa { get; set; }
        public PerguntaViewModel Pergunta { get; set; }

        public Object GetResposta()
        {
            return new Resposta()
            {
                Id = this.Id,
                PerguntaId = this.PerguntaId,
                AlternativaId = this.AlternativaId,
                Texto = this.Texto,
                TextoCurto = this.TextoCurto,
                Numerica = this.Numerica,
                Data = this.Data,
                Token = this.Token,
                Alternativa = this.Alternativa.GetAlternativa() as Alternativa,
                Pergunta = this.Pergunta.GetPergunta() as Pergunta
            };
        }
    }
}
