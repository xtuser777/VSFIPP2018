using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.Models
{
    internal class Usuario
    {
        private int _codigo;
        private string _nome;
        private string _login;
        private string _senha;
        private DateTime _dataAdmissao;
        private DateTime _dataDemissao;
        private string _cpf;
        private string _rg;
        private int _nivelCodigo;
        private int _localCodigo;
        private Nivel nivel;
        private Local local;

        internal int Codigo { get => _codigo; set => _codigo = value; }
        internal string Nome { get => _nome; set => _nome = value; }
        internal string Login { get => _login; set => _login = value; }
        internal string Senha { get => _senha; set => _senha = value; }
        internal DateTime DataAdmissao { get => _dataAdmissao; set => _dataAdmissao = value; }
        internal DateTime DataDemissao { get => _dataDemissao; set => _dataDemissao = value; }
        internal string Cpf { get => _cpf; set => _cpf = value; }
        internal string Rg { get => _rg; set => _rg = value; }
        internal int NivelCodigo { get => _nivelCodigo; set => _nivelCodigo = value; }
        internal int LocalCodigo { get => _localCodigo; set => _localCodigo = value; }
        internal Nivel Nivel { get => nivel; set => nivel = value; }
        internal Local Local { get => local; set => local = value; }

        internal Usuario Obter(int codigo)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            if(codigo > 0)
            {
                usuario = usuarioDAO.Obter(codigo);
            }
            else
            {
                usuario = null;
            }
            return usuario;
        }

        internal List<Usuario> ObterAtivos(int nivel)
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            if(nivel > 0)
            {
                usuarios = usuarioDAO.ObterAtivos(nivel);
            }
            else
            {
                usuarios = null;
            }
            return usuarios;
        }

        internal List<Usuario> ObterAtivos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarios = usuarioDAO.ObterAtivos();
            return usuarios;
        }

        internal List<Usuario> ObterDesativados()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarios = usuarioDAO.ObterDesativados();
            return usuarios;
        }

        internal Usuario Autenticar(string login, string senha)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            if(login.Length > 0 && senha.Length > 0)
            {
                usuario = usuarioDAO.Autenticar(login, senha);
            }
            else
            {
                usuario = null;
            }
            return usuario;
        }

        internal int Gravar()
        {
            int retorno;
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            retorno = usuarioDAO.Gravar(this);
            return retorno;
        }

        internal int Alterar()
        {
            int retorno;
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            retorno = usuarioDAO.Alterar(this);
            return retorno;
        }

        internal int Desativar(int codigo)
        {
            int retorno;
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            retorno = usuarioDAO.Desativar(codigo);
            return retorno;
        }

        internal int Reativar(int codigo)
        {
            int retorno;
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            retorno = usuarioDAO.Reativar(codigo);
            return retorno;
        }
    }
}
