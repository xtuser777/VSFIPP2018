using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModels
{
    public class TipoPerguntaViewModel
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public List<PerguntaViewModel> Perguntas { get; set; }

        public Object GetTipoPergunta()
        {
            List<Pergunta> perguntas = new List<Pergunta>();
            foreach(PerguntaViewModel pvm in this.Perguntas)
            {
                perguntas.Add(pvm.GetPergunta() as Pergunta);
            }

            return new TipoPergunta()
            {
                Id = this.Id,
                Nome = this.Nome,
                Perguntas = perguntas
            };
        }
    }
}
