using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Nivel
    {
        private int _codigo;
        private string _nome;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Nome { get => _nome; set => _nome = value; }

        internal Nivel Obter(int codigo)
        {
            Nivel nivel = new Nivel();
            NivelDAO nivelDAO = new NivelDAO();
            nivel = nivelDAO.Obter(codigo);
            return nivel;
        }

        internal List<Nivel> Obter()
        {
            List<Nivel> niveis = new List<Nivel>();
            NivelDAO nivelDAO = new NivelDAO();
            niveis = nivelDAO.Obter();
            return niveis;
        }

        internal int Gravar()
        {
            int retorno;
            NivelDAO nivelDAO = new NivelDAO();
            retorno = nivelDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            NivelDAO nivelDAO = new NivelDAO();
            retorno = nivelDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int codigo)
        {
            int retorno;
            NivelDAO nivelDAO = new NivelDAO();
            retorno = nivelDAO.Excluir(codigo);
            return retorno;
        }
    }
}
