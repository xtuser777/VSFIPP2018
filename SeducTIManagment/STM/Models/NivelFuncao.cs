using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class NivelFuncao
    {
        private int _nivelCodigo;
        private int _funcaoCodigo;

        internal int NivelCodigo { get => _nivelCodigo; set => _nivelCodigo = value; }
        internal int FuncaoCodigo { get => _funcaoCodigo; set => _funcaoCodigo = value; }

        internal List<Funcao> ObterFuncPorNiv(int nivel)
        {
            List<Funcao> funcoes = new List<Funcao>();
            NivelFuncaoDAO nivelFuncaoDAO = new NivelFuncaoDAO();
            funcoes = nivelFuncaoDAO.ObterFuncPorNiv(nivel);
            return funcoes;
        }

        internal Nivel ObterNivelPorFunc(int funcao)
        {
            Nivel nivel = new Nivel();
            NivelFuncaoDAO nivelFuncaoDAO = new NivelFuncaoDAO();
            nivel = nivelFuncaoDAO.ObterNivelPorFunc(funcao);
            return nivel;
        }

        internal int Gravar()
        {
            int retorno;
            NivelFuncaoDAO nivelFuncaoDAO = new NivelFuncaoDAO();
            retorno = nivelFuncaoDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            NivelFuncaoDAO nivelFuncaoDAO = new NivelFuncaoDAO();
            retorno = nivelFuncaoDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int nivel, int funcao)
        {
            int retorno;
            NivelFuncaoDAO nivelFuncaoDAO = new NivelFuncaoDAO();
            retorno = nivelFuncaoDAO.Excluir(nivel, funcao);
            return retorno;
        }
    }
}
