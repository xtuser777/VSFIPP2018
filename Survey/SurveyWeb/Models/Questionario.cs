using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWeb.Models
{
    public class Questionario
    {
        private int _id;
        private string _nome;
        private DateTime _inicio;
        private DateTime _fim;
        private string _guid;
        private Usuario _usuario;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public DateTime Inicio { get => _inicio; set => _inicio = value; }
        public DateTime Fim { get => _fim; set => _fim = value; }
        public string Guid { get => _guid; set => _guid = value; }
        public Usuario Usuario { get => _usuario; set => _usuario = value; }
    }
}