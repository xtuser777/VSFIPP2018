using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Funcao
    {
        private int _codigo;
        private string _nome;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Nome { get => _nome; set => _nome = value; }

        internal Funcao Obter(int codigo)
        {
            Funcao funcao = new Funcao();
            FuncaoDAO funcaoDAO = new FuncaoDAO();
            funcao = funcaoDAO.Obter(codigo);
            return funcao;
        }

        internal List<Funcao> Obter()
        {
            List<Funcao> funcoes = new List<Funcao>();
            FuncaoDAO funcaoDAO = new FuncaoDAO();
            funcoes = funcaoDAO.Obter();
            return funcoes;
        }

        internal int Gravar()
        {
            int retorno;
            FuncaoDAO funcaoDAO = new FuncaoDAO();
            retorno = funcaoDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            FuncaoDAO funcaoDAO = new FuncaoDAO();
            retorno = funcaoDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int codigo)
        {
            int retorno;
            FuncaoDAO funcaoDAO = new FuncaoDAO();
            retorno = funcaoDAO.Excluir(codigo);
            return retorno;
        }
    }
}
