using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWeb.Models
{
    internal class Alternativa
    {
        private int _id;
        private string _opcao;
        private int _ordem;
        private Pergunta _pergunta;

        public int Id { get => _id; set => _id = value; }
        public string Opcao { get => _opcao; set => _opcao = value; }
        public int Ordem { get => _ordem; set => _ordem = value; }
        public Pergunta Pergunta { get => _pergunta; set => _pergunta = value; }

        public Alternativa(int id, string opcao, int ordem, Pergunta pergunta)
        {
            Id = id;
            Opcao = opcao;
            Ordem = ordem;
            Pergunta = pergunta;
        }
    }
}