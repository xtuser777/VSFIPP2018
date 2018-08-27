using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjAcademico.Models
{
    public class Funcionario
    {
        private int _codigo;
        private string _nome;
        private char _ativo;
        private char _tipo;
        private DateTime _dtContratacao;
        private DateTime _dtDemissao;

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public char Ativo { get => _ativo; set => _ativo = value; }
        public char Tipo { get => _tipo; set => _tipo = value; }
        public DateTime DtContratacao { get => _dtContratacao; set => _dtContratacao = value; }
        public DateTime DtDemissao { get => _dtDemissao; set => _dtDemissao = value; }
    }
}