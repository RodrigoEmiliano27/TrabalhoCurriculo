using JogosCadastro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JogosCadastro.DAO
{
    public class JogoDAO
    {
        public void Inserir(JogoViewModel jogo)
        {
            string sql =
            "insert into jogos(id, descricao, valor_locacao, data_aquisicao, categoriaID)" +
            "values ( @id, @descricao, @valor_locacao, @data_aquisicao, @categoriaID)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(jogo));
        }
        public void Alterar(JogoViewModel jogo)
        {
            string sql =
            "update jogos set descricao = @descricao, " +
            "valor_locacao = @valor_locacao, " +
            "data_aquisicao = @data_aquisicao," +
            "categoriaID = @categoriaID where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(jogo));
        }
        private SqlParameter[] CriaParametros(JogoViewModel jogo)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", jogo.Id);
            parametros[1] = new SqlParameter("descricao", jogo.Descricao);
            parametros[2] = new SqlParameter("valor_locacao", jogo.Valor_Locacao);
            parametros[3] = new SqlParameter("data_aquisicao", jogo.Data_Aquisicao);
            parametros[4] = new SqlParameter("categoriaID", jogo.Categoria);
            return parametros;
        }
        public void Excluir(int id)
        {
            string sql = "delete jogos where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }
        public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from jogos";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
        private JogoViewModel MontaAluno(DataRow registro)
        {
            JogoViewModel a = new JogoViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Descricao = registro["descricao"].ToString();
            a.Valor_Locacao = Convert.ToDouble(registro["valor_locacao"]);
            a.Data_Aquisicao = Convert.ToDateTime(registro["data_aquisicao"]);
            a.Categoria = Convert.ToInt32(registro["categoriaID"]);
            return a;
        }

        public JogoViewModel Consulta(int id)
        {
            string sql = "select * from jogos where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaAluno(tabela.Rows[0]);
        }
        public List<JogoViewModel> Listagem()
        {
            List<JogoViewModel> lista = new List<JogoViewModel>();
            string sql = "select * from jogos order by descricao";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaAluno(registro));
            return lista;
        }
    }
}
