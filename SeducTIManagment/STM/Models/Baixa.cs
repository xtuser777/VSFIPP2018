using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Baixa
    {
        private int _codigo;
        private string _motivo;
        private DateTime _data;
        private int _usuarioCodigo;
        private Usuario _usuario;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Motivo { get => _motivo; set => _motivo = value; }
        internal DateTime Data { get => _data; set => _data = value; }
        internal int UsuarioCodigo { get => _usuarioCodigo; set => _usuarioCodigo = value; }
        internal Usuario Usuario { get => _usuario; set => _usuario = value; }

        internal Baixa Obter(int codigo)
        {
            Baixa baixa = new Baixa();
            BaixaDAO baixaDAO = new BaixaDAO();
            if(codigo > 0)
            {
                baixa = baixaDAO.Obter(codigo);
            }
            else
            {
                baixa = null;
            }
            return baixa;
        }

        internal List<Baixa> Obter()
        {
            List<Baixa> baixas = new List<Baixa>();
            BaixaDAO baixaDAO = new BaixaDAO();
            baixas = baixaDAO.Obter();
            return baixas;
        }

        internal List<Baixa> Obter(int motivo, DateTime data)
        {
            List<Baixa> baixas = new List<Baixa>();
            BaixaDAO baixaDAO = new BaixaDAO();
            baixas = baixaDAO.ObterPorData(motivo, data);
            return baixas;
        }

        internal int Gravar()
        {
            int retorno;
            BaixaDAO baixaDAO = new BaixaDAO();
            retorno = baixaDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            BaixaDAO baixaDAO = new BaixaDAO();
            retorno = baixaDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int codigo)
        {
            int retorno;
            BaixaDAO baixaDAO = new BaixaDAO();
            retorno = baixaDAO.Excluir(codigo);
            return retorno;
        }
    }
}
