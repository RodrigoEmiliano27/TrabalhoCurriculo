using JogosCadastro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JogosCadastro.DAO
{
    public class CurriculoDAO
    {
        public void Inserir(CurriculoViewModel Curriculo)
        {
            string sql =
            "insert into Curriculos(id, nome, telefone, email, cargoPretendido)" +
            "values ( @id, @nome, @telefone, @email, @cargoPretendido)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Curriculo));
        }
        public void Alterar(CurriculoViewModel Curriculo)
        {
            string sql =
            "update Curriculos set nome = @nome, " +
            "telefone = @telefone, " +
            "email = @email," +
            "cargoPretendido = @cargoPretendido where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Curriculo));
        }
        private SqlParameter[] CriaParametros(CurriculoViewModel Curriculo)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[1] = new SqlParameter("nome", Curriculo.Nome);
            parametros[2] = new SqlParameter("telefone", Curriculo.Telefone);
            parametros[3] = new SqlParameter("email", Curriculo.Email);
            parametros[4] = new SqlParameter("cargoPretendido", Curriculo.Cargo_Pretendido);
            return parametros;
        }
        public void Excluir(int id)
        {
            string sql = "delete Curriculos where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }
        public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from jogos";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
        private CurriculoViewModel MontaCurriculo(DataRow registro)
        {
            CurriculoViewModel a = new CurriculoViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Descricao = registro["descricao"].ToString();
            a.Valor_Locacao = Convert.ToDouble(registro["valor_locacao"]);
            a.Data_Aquisicao = Convert.ToDateTime(registro["data_aquisicao"]);
            a.Categoria = Convert.ToInt32(registro["categoriaID"]);
            return a;
        }

        public CurriculoViewModel Consulta(int id)
        {
            string sql = "select * from jogos where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaCurriculo(tabela.Rows[0]);
        }
        public List<CurriculoViewModel> Listagem()
        {
            List<CurriculoViewModel> lista = new List<CurriculoViewModel>();
            string sql = "select * from jogos order by descricao";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaCurriculo(registro));
            return lista;
        }
    }
}
