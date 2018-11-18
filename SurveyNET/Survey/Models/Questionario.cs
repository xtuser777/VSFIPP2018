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
        private string _imagem64;
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

        internal string Imagem64
        {
            get
            {
                return _imagem64;
            }

            set
            {
                _imagem64 = value;
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

        internal int Gravar()
        {
            if(this.Id == 0 && this.Nome.Length > 2 && this.Guid.Length > 2 && this.UsuarioId > 0)
            {
                return new QuestionarioDAO().Gravar(this);
            }
            else
            {
                return -10;
            }
        }

        internal int Alterar()
        {
            if (this.Id > 0 && this.Nome.Length > 2 && this.Inicio <= DateTime.Now && this.Guid.Length > 2 && this.UsuarioId > 0)
            {
                return new QuestionarioDAO().Alterar(this);
            }
            else
            {
                return -10;
            }
        }

        internal int Excluir(int id)
        {
            if (id > 0)
                return new QuestionarioDAO().Excluir(id);
            else
                return -10;
        }

        internal List<Questionario> ObterPorUsuario(int id)
        {
            if (id > 0)
                return new QuestionarioDAO().Obter(id);
            else
                return null;
        }

        internal Questionario ObterPorId(int userId, int id)
        {
            if (id > 0 && userId > 0)
            {
                return new QuestionarioDAO().Obter(userId, id);
            }
            else
            {
                return null;
            }
        }

        internal List<Questionario> ObterPorPalavraChave(int userId, string chave)
        {
            if (userId > 0 && chave.Length > 0)
            {
                return new QuestionarioDAO().Obter(userId, chave);
            }
            else
            {
                return null;
            }
        }

        internal Questionario Obter(string guid)
        {
            if(guid != null && guid.Length > 0)
            {
                return new QuestionarioDAO().Obter(guid);
            }
            else
            {
                return null;
            }
        }
    }
}
