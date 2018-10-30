using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Marca
    {
        private int _codigo;
        private string _nome;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Nome { get => _nome; set => _nome = value; }

        internal Marca Obter(int codigo)
        {
            Marca marca = new Marca();
            MarcaDAO marcaDAO = new MarcaDAO();
            marca = marcaDAO.Obter(codigo);
            return marca;
        }

        internal int Gravar()
        {
            int retorno;
            MarcaDAO marcaDAO = new MarcaDAO();
            retorno = marcaDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            MarcaDAO marcaDAO = new MarcaDAO();
            retorno = marcaDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int codigo)
        {
            int retorno;
            MarcaDAO marcaDAO = new MarcaDAO();
            retorno = marcaDAO.Excluir(codigo);
            return retorno;
        }
    }
}
