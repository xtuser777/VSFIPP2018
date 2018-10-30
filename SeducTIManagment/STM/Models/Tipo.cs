using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Tipo
    {
        private int _codigo;
        private string _nome;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Nome { get => _nome; set => _nome = value; }

        internal Tipo Obter(int codigo)
        {
            Tipo tipo = new Tipo();
            TipoDAO tipoDAO = new TipoDAO();
            tipo = tipoDAO.Obter(codigo);
            return tipo;
        }

        internal int Gravar()
        {
            int retorno;
            TipoDAO tipoDAO = new TipoDAO();
            retorno = tipoDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            TipoDAO tipoDAO = new TipoDAO();
            retorno = tipoDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int codigo)
        {
            int retorno;
            TipoDAO tipoDAO = new TipoDAO();
            retorno = tipoDAO.Excluir(codigo);
            return retorno;
        }
    }
}
