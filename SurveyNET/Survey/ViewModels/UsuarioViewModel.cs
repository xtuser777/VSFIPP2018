﻿using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataFim { get; set; }
        public List<QuestionarioViewModel> Questionarios { get; set; }

        public Object GetUsuario()
        {
            return new Usuario()
            {
                Id = this.Id,
                Nome = this.Nome,
                Email = this.Email,
                Senha = this.Senha,
                DataCadastro = this.DataCadastro,
                DataFim = this.DataFim
            };
        }
    }
}
