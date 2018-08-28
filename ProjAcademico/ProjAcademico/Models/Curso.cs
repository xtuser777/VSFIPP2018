using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjAcademico.Models
{
    public class Curso
    {
        private int _codigo;
        private string _nome;
        private char _ativo;
        private Categoria _categoria;

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public char Ativo { get => _ativo; set => _ativo = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }
    }
}