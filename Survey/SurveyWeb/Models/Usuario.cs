using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWeb.Models
{
    internal class Usuario
    {
        private int _id;
        private string _nome;
        private string _email;
        private string _senha;
        private DateTime _dataCadastro;
        private DateTime _dataFim;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public DateTime DataCadastro { get => _dataCadastro; set => _dataCadastro = value; }
        public DateTime DataFim { get => _dataFim; set => _dataFim = value; }
    }
}