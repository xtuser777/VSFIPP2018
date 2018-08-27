using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjAcademico.Models
{
    public class Usuario
    {
        private int _funCodigo;
        private string _senha;
        private DateTime _ultimoAcesso;
        private char _nivel;

        public int FunCodigo { get => _funCodigo; set => _funCodigo = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public DateTime UltimoAcesso { get => _ultimoAcesso; set => _ultimoAcesso = value; }
        public char Nivel { get => _nivel; set => _nivel = value; }
    }
}