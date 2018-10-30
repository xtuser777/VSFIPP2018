using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Parametrizacao
    {
        private string _cnpj;
        private string _razaoSocial;
        private string _nomeFantasia;
        private string _inscEstadual;
        private string _logradouro;
        private string _numero;
        private string _bairro;
        private string _cidade;
        private string _uf;
        private string _urlLogo;

        internal string Cnpj { get => _cnpj; set => _cnpj = value; }
        internal string RazaoSocial { get => _razaoSocial; set => _razaoSocial = value; }
        internal string NomeFantasia { get => _nomeFantasia; set => _nomeFantasia = value; }
        internal string InscEstadual { get => _inscEstadual; set => _inscEstadual = value; }
        internal string Logradouro { get => _logradouro; set => _logradouro = value; }
        internal string Numero { get => _numero; set => _numero = value; }
        internal string Bairro { get => _bairro; set => _bairro = value; }
        internal string Cidade { get => _cidade; set => _cidade = value; }
        internal string Uf { get => _uf; set => _uf = value; }
        internal string UrlLogo { get => _urlLogo; set => _urlLogo = value; }

        internal Parametrizacao Obter(string cnpj)
        {
            Parametrizacao parametrizacao = new Parametrizacao();
            ParametrizacaoDAO parametrizacaoDAO = new ParametrizacaoDAO();
            if(cnpj.Length > 0)
            {
                parametrizacao = parametrizacaoDAO.Obter(cnpj);
            }
            else
            {
                parametrizacao = null;
            }
            return parametrizacao;
        }

        internal int Gravar()
        {
            int retorno;
            ParametrizacaoDAO parametrizacaoDAO = new ParametrizacaoDAO();
            retorno = parametrizacaoDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            ParametrizacaoDAO parametrizacaoDAO = new ParametrizacaoDAO();
            retorno = parametrizacaoDAO.Alterar(this);
            return retorno;
        }
    }
}
