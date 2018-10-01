using Survey.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    internal class Questionario
    {
        private int _id;
        private string _nome;
        private DateTime _inicio;
        private DateTime _fim;
        private string _msgFeedback;
        private string _guid;
        private string _imagem;
        private int _usuarioId;
        private Usuario _usuario;
        private List<Pergunta> _perguntas;

        internal int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        internal string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }

        internal DateTime Inicio
        {
            get
            {
                return _inicio;
            }
            set
            {
                _inicio = value;
            }
        }

        internal DateTime Fim
        {
            get
            {
                return _fim;
            }
            set
            {
                _fim = value;
            }
        }

        internal string MsgFeedback
        {
            get
            {
                return _msgFeedback;
            }
            set
            {
                _msgFeedback = value;
            }
        }

        internal string Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

        internal string Imagem
        {
            get
            {
                return _imagem;
            }
            set
            {
                _imagem = value;
            }
        }

        internal int UsuarioId
        {
            get
            {
                return _usuarioId;
            }
            set
            {
                _usuarioId = value;
            }
        }

        internal Usuario Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }

        internal List<Pergunta> Perguntas
        {
            get
            {
                return _perguntas;
            }
            set
            {
                _perguntas = value;
            }
        }

        internal List<Questionario> ObterPorUsuario(int id)
        {
            if (id > 0)
                return new QuestionarioDAO().ObterPorUsuario(id);
            else
                return null;
        }
    }
}
