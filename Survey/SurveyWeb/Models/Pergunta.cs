using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWeb.Models
{
    public class Pergunta
    {
        private int _id;
        private string _titulo;
        private string _descricao;
        private string _dica;
        private char _obrigatorio;
        private decimal _ordem;
        private TipoPergunta _tipo;
        private Questionario _questionario;

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public string Dica { get => _dica; set => _dica = value; }
        public char Obrigatorio { get => _obrigatorio; set => _obrigatorio = value; }
        public decimal Ordem { get => _ordem; set => _ordem = value; }
        public TipoPergunta Tipo { get => _tipo; set => _tipo = value; }
        public Questionario Questionario { get => _questionario; set => _questionario = value; }
    }
}