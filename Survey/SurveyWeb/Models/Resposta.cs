using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWeb.Models
{
    internal class Resposta
    {
        private int _id;
        private Pergunta _pergunta;
        private Alternativa _alternativa;
        private string _texto;
        private string _textoCurto;
        private decimal _numerico;
        private DateTime _data;
        private string _token;

        public int Id { get => _id; set => _id = value; }
        public Pergunta Pergunta { get => _pergunta; set => _pergunta = value; }
        public Alternativa Alternativa { get => _alternativa; set => _alternativa = value; }
        public string Texto { get => _texto; set => _texto = value; }
        public string TextoCurto { get => _textoCurto; set => _textoCurto = value; }
        public decimal Numerico { get => _numerico; set => _numerico = value; }
        public DateTime Data { get => _data; set => _data = value; }
        public string Token { get => _token; set => _token = value; }
    }
}