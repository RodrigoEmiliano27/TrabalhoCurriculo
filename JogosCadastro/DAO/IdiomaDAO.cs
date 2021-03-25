using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Models;

namespace TrabalhoCurriculo.DAO
{
    public class IdiomaDAO
    {
        public void Inserir(IdiomaViewModel Idioma)
        {
            string sql =
            "insert into Idiomas(idCurriculo, Idioma, Nivel)" +
            "values ( @idCurriculo, @Idioma, @Nivel)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Idioma));
        }
        public void Alterar(IdiomaViewModel Idioma)
        {
            string sql =
            "update Idiomas set Idioma = @Idioma, " +
            "Nivel = @Nivel, " +
            "where id = @id and idCurriculo=@idCurriculo";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Idioma));
        }
        private SqlParameter[] CriaParametros(IdiomaViewModel Idioma)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("id", Idioma.Id);
            parametros[1] = new SqlParameter("idCurriculo", Idioma.IdCurriculo);
            parametros[2] = new SqlParameter("Idioma", Idioma.Idioma);
            parametros[3] = new SqlParameter("Nivel", Idioma.Nivel);
            return parametros;
        }
        public void Excluir(int id, int idCurriculo)
        {
            string sql = "delete Idiomas where id =" + id + "AND idCurriculo=" + idCurriculo;
            HelperDAO.ExecutaSQL(sql, null);
        }
        /*public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from jogos";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }*/
        private IdiomaViewModel MontarIdioma(DataRow registro)
        {
            IdiomaViewModel a = new IdiomaViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.IdCurriculo = Convert.ToInt32(registro["idCurriculo"]);
            a.Idioma = registro["Idioma"].ToString();
            a.Nivel = registro["Nivel"].ToString();
            return a;
        }

        public List<IdiomaViewModel> Consulta(int idCurriculo)
        {
            List<IdiomaViewModel> Lista = new List<IdiomaViewModel>();
            string sql = "select * from Idiomas where idCurriculo = " + idCurriculo;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return Lista;
            else
            {
                for (int n = 0; n < tabela.Rows.Count; n++)
                    Lista.Add(MontarIdioma(tabela.Rows[n]));
                return Lista;
            }

        }
    }
}
