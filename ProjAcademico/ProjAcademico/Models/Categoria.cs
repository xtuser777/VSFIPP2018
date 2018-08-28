using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjAcademico.Models
{
    public class Categoria
    {
        private int _codigo;
        private string _nome;

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nome { get => _nome; set => _nome = value; }
    }
}