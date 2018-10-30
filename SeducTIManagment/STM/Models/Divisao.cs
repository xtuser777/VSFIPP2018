using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Divisao
    {
        private int _codigo;
        private string _nome;
        private int _localCodigo;
        private Local _local;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Nome { get => _nome; set => _nome = value; }
        internal int LocalCodigo { get => _localCodigo; set => _localCodigo = value; }
        internal Local Local { get => _local; set => _local = value; }

        internal Divisao Obter(int codigo)
        {
            Divisao divisao = new Divisao();
            DivisaoDAO divisaoDAO = new DivisaoDAO();
            divisao = divisaoDAO.Obter(codigo);
            return divisao;
        }

        internal Divisao Obter(string nome)
        {
            Divisao divisao = new Divisao();
            DivisaoDAO divisaoDAO = new DivisaoDAO();
            divisao = divisaoDAO.Obter(nome);
            return divisao;
        }

        internal List<Divisao> ObterPorLocal(int local)
        {
            List<Divisao> divisoes = new List<Divisao>();
            DivisaoDAO divisaoDAO = new DivisaoDAO();
            divisoes = divisaoDAO.ObterPorLocal(local);
            return divisoes;
        }

        internal int Gravar()
        {
            int retorno;
            DivisaoDAO divisaoDAO = new DivisaoDAO();
            retorno = divisaoDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            DivisaoDAO divisaoDAO = new DivisaoDAO();
            retorno = divisaoDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int codigo)
        {
            int retorno;
            DivisaoDAO divisaoDAO = new DivisaoDAO();
            retorno = divisaoDAO.Excluir(codigo);
            return retorno;
        }
    }
}
