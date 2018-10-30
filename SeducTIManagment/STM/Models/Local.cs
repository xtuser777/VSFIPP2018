using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Local
    {
        private int _codigo;
        private string _nome;
        private string _tipo;
        private string _logradouro;
        private string _bairro;
        private string _uf;
        private string _cidade;
        private string _cep;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Nome { get => _nome; set => _nome = value; }
        internal string Tipo { get => _tipo; set => _tipo = value; }
        internal string Logradouro { get => _logradouro; set => _logradouro = value; }
        internal string Bairro { get => _bairro; set => _bairro = value; }
        internal string Uf { get => _uf; set => _uf = value; }
        internal string Cidade { get => _cidade; set => _cidade = value; }
        internal string Cep { get => _cep; set => _cep = value; }

        internal Local Obter(int codigo)
        {
            Local local = new Local();
            LocalDAO localDAO = new LocalDAO();
            if(codigo > 0)
            {
                local = localDAO.Obter(codigo);
            }
            else
            {
                local = null;
            }
            return local;
        }

        internal int Gravar()
        {
            int retorno;
            LocalDAO localDAO = new LocalDAO();
            retorno = localDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            LocalDAO localDAO = new LocalDAO();
            retorno = localDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int codigo)
        {
            int retorno;
            LocalDAO localDAO = new LocalDAO();
            retorno = localDAO.Excluir(codigo);
            return retorno;
        }
    }
}
