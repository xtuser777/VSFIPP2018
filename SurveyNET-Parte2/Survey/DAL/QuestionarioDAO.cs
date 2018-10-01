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
                             Imagem = row["Imagem"].ToString(),
                             Perguntas = null,
                             Usuario = null
                         }).ToList();
            return dados;
        }

        internal List<Questionario> ObterPorUsuario(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select Id, Nome, Inicio, Fim, MsgFeedback, Guid, Imagem, UsuarioId 
                                        from Questionario 
                                        where UsuarioId = @id
                                        order by Inicio desc";
            ComandoSQL.Parameters.AddWithValue("@id", id);
            DataTable dt = ExecutaSelect();
            return TableToList(dt);
        }
    }
}
