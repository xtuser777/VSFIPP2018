using Survey.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL
{
    internal class QuestionarioDAO : Banco
    {
        private List<Questionario> TableToList(DataTable dt)
        {
            List<Questionario> dados = null;
            if (dt != null && dt.Rows.Count > 0)
                dados = (from DataRow row in dt.Rows
                         select new Questionario()
                         {
                             Id = Convert.ToInt32(row["Id"]),
                             Nome = row["Nome"].ToString(),
                             MsgFeedback = row["MsgFeedback"].ToString(),
                             Guid = row["Guid"].ToString(),
                             Inicio = Convert.ToDateTime(row["Inicio"]),
                             Fim = Convert.ToDateTime(row["Fim"]),
                             UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                             Imagem64 = row["Imagem64"].ToString(),
                             Perguntas = null,
                             Usuario = null
                         }).ToList();
            return dados;
        }

        internal List<Questionario> Obter(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select Id, Nome, Inicio, Fim, MsgFeedback, Guid, Imagem64, UsuarioId 
                                        from Questionario 
                                        where UsuarioId = @id
                                        order by Inicio desc";
            ComandoSQL.Parameters.AddWithValue("@id", id);
            DataTable dt = ExecutaSelect();
            return TableToList(dt);
        }

        internal Questionario Obter(int userId, int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select Id, Nome, Inicio, Fim, MsgFeedback, Guid, Imagem64, UsuarioId
                                       from Questionario
                                       where UsuarioId = @userid and Id = @id
                                       order by Inicio desc;";
            ComandoSQL.Parameters.AddWithValue("@userid", userId);
            ComandoSQL.Parameters.AddWithValue("@id", id);
            DataTable dt = ExecutaSelect();
            var dados = TableToList(dt);
            return dados == null ? null : dados.FirstOrDefault();
        }

        internal List<Questionario> Obter(int userId, string chave)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select Id, Nome, Inicio, Fim, MsgFeedback, Guid, Imagem, UsuarioId
                                       from Questionario
                                       where UsuarioId = @userid and Nome like @chave 
                                       order by Inicio desc;";
            ComandoSQL.Parameters.AddWithValue("@userid", userId);
            ComandoSQL.Parameters.AddWithValue("@chave", "%"+chave+"%");
            DataTable dt = ExecutaSelect();
            return TableToList(dt);
        }

        internal Questionario Obter(string guid)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select Id, Nome, Inicio, Fim, MsgFeedback, Guid, Imagem64, UsuarioId
                                       from Questionario
                                       where Guid = @guid
                                       order by Inicio desc;";
            ComandoSQL.Parameters.AddWithValue("@guid", guid);
            DataTable dt = ExecutaSelect();
            var dados = TableToList(dt);
            return dados == null ? null : dados.FirstOrDefault();
        }

        internal int Gravar(Questionario q)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"insert into Questionario (Nome, Inicio, Fim, MsgFeedback, Guid, Imagem64, UsuarioId)
                                           values(@nome, @inicio, @fim, @msgFeedbck, @guid, @imagem64, @usuarioid);";
            ComandoSQL.Parameters.AddWithValue("@id", q.Id);
            ComandoSQL.Parameters.AddWithValue("@nome", q.Nome);
            ComandoSQL.Parameters.AddWithValue("@inicio", q.Inicio);
            ComandoSQL.Parameters.AddWithValue("@fim", q.Fim);
            ComandoSQL.Parameters.AddWithValue("@msgFeedbck", q.MsgFeedback);
            ComandoSQL.Parameters.AddWithValue("@guid", q.Guid);
            ComandoSQL.Parameters.AddWithValue("@imagem64", q.Imagem64);
            ComandoSQL.Parameters.AddWithValue("@usuarioid", q.UsuarioId);

            return ExecutaComando();
        }

        internal int Alterar(Questionario q)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"update Questionario set 
                                        Nome = @nome, 
                                        Inicio = @inicio, 
                                        Fim = @fim, 
                                        MsgFeedback = @msgFeedbck, 
                                        Guid = @guid, 
                                        Imagem64 = @imagem64,
                                        UsuarioId = @userid 
                                        where Id = @id;";
            ComandoSQL.Parameters.AddWithValue("@id", q.Id);
            ComandoSQL.Parameters.AddWithValue("@nome", q.Nome);
            ComandoSQL.Parameters.AddWithValue("@inicio", q.Inicio);
            ComandoSQL.Parameters.AddWithValue("@fim", q.Fim);
            ComandoSQL.Parameters.AddWithValue("@msgFeedbck", q.MsgFeedback);
            ComandoSQL.Parameters.AddWithValue("@guid", q.Guid);
            ComandoSQL.Parameters.AddWithValue("@imagem64", q.Imagem64);
            ComandoSQL.Parameters.AddWithValue("@userid", q.UsuarioId);

            return ExecutaComando();
        }

        internal int Excluir(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from Questionario where id = @id;";
            ComandoSQL.Parameters.AddWithValue("@id", id);

            return ExecutaComando();
        }
    }
}
