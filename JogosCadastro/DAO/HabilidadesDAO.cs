using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Models;

namespace TrabalhoCurriculo.DAO
{
    public class HabilidadesDAO
    {
        public void Inserir(HabilidadesViewModel Habilidade)
        {
            string sql =
            "insert into Habilidades(id,idCurriculo, Descricao, Nivel)" +
            "values ( @id,@idCurriculo @Descricao, @Nivel)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Habilidade));
        }
        public void Alterar(HabilidadesViewModel Habilidade)
        {
            string sql =
            "update Idiomas set Descricao = @Descricao, " +
            "Nivel = @Nivel, " +
            "where id = @id and idCurriculo=@idCurriculo";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Habilidade));
        }
        private SqlParameter[] CriaParametros(HabilidadesViewModel Habilidade)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("id", Habilidade.Id);
            parametros[1] = new SqlParameter("idCurriculo", Habilidade.IdCurriculo);
            parametros[2] = new SqlParameter("Descricao", Habilidade.Descricao) ;
            parametros[3] = new SqlParameter("Nivel", Habilidade.Nivel);
            return parametros;
        }
        public void Excluir(int id, int idCurriculo)
        {
            string sql = "delete Habilidades where id =" + id + " idCurriculo=" + idCurriculo;
            HelperDAO.ExecutaSQL(sql, null);
        }
        /*public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from jogos";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }*/
        private HabilidadesViewModel MontarHabilidade(DataRow registro)
        {
            HabilidadesViewModel a = new HabilidadesViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.IdCurriculo = Convert.ToInt32(registro["idCurriculo"]);
            a.Descricao = registro["Descricao"].ToString();
            a.Nivel = Convert.ToInt32(registro["Nivel"]);
            return a;
        }

        public List<HabilidadesViewModel> Consulta(int idCurriculo)
        {
            List<HabilidadesViewModel> Lista = new List<HabilidadesViewModel>();
            string sql = "select * from Habilidades where idCurriculo = " + idCurriculo;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
            {
                for (int n = 0; n < tabela.Rows.Count; n++)
                    Lista.Add(MontarHabilidade(tabela.Rows[n]));
                return Lista;
            }

        }
    }
}
