using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Modelo
    {
        private int _codigo;
        private string _nome;
        private string _descricao;
        private int _marcaCodigo;
        private int _tipoCodigo;
        private Marca _marca;
        private Tipo _tipo;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Nome { get => _nome; set => _nome = value; }
        internal string Descricao { get => _descricao; set => _descricao = value; }
        internal int MarcaCodigo { get => _marcaCodigo; set => _marcaCodigo = value; }
        internal int TipoCodigo { get => _tipoCodigo; set => _tipoCodigo = value; }
        internal Marca Marca { get => _marca; set => _marca = value; }
        internal Tipo Tipo { get => _tipo; set => _tipo = value; }

        internal Modelo Obter(int codigo)
        {
            Modelo modelo = new Modelo();
            ModeloDAO modeloDAO = new ModeloDAO();
            modelo = modeloDAO.Obter(codigo);
            return modelo;
        }

        internal List<Modelo> Obter()
        {
            List<Modelo> modelos = new List<Modelo>();
            ModeloDAO modeloDAO = new ModeloDAO();
            modelos = modeloDAO.Obter();
            return modelos;
        }

        internal List<Modelo> Obter(int marca, int tipo)
        {
            List<Modelo> modelos = new List<Modelo>();
            ModeloDAO modeloDAO = new ModeloDAO();
            modelos = modeloDAO.ObterPorTipo(marca, tipo);
            return modelos;
        }

        internal int Gravar()
        {
            int retorno;
            ModeloDAO modeloDAO = new ModeloDAO();
            retorno = modeloDAO.Gravar(this);
            return retorno;
        }

        internal int Altarar()
        {
            int retorno;
            ModeloDAO modeloDAO = new ModeloDAO();
            retorno = modeloDAO.Alterar(this);
            return retorno;
        }

        internal int Excluir(int codigo)
        {
            int retorno;
            ModeloDAO modeloDAO = new ModeloDAO();
            retorno = modeloDAO.Excluir(codigo);
            return retorno;
        }
    }
}
