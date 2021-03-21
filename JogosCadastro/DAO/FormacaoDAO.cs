using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Models;

namespace TrabalhoCurriculo.DAO
{
    public class FormacaoDAO
    {
        public void Inserir(FormacaoViewModel Formacao)
        {
            string sql =
            "insert into FormacaoAcademica(idCurriculo, instituicao, inicio, fim)" +
            "values (@idCurriculo @instituicao, @inicio, @fim)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Formacao));
        }
        public void Alterar(FormacaoViewModel Formacao)
        {
            string sql =
            "update FormacaoAcademica set instituicao = @instituicao, " +
            "inicio = @inicio, " +
            "fim = @fim," +
            "where id = @id and idCurriculo=@idCurriculo";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Formacao));
        }
        private SqlParameter[] CriaParametros(FormacaoViewModel Formacao)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", Formacao.Id);
            parametros[1] = new SqlParameter("idCurriculo", Formacao.IdCurriculo);
            parametros[2] = new SqlParameter("instituicao", Formacao.Instituicao);
            parametros[3] = new SqlParameter("inicio", Formacao.Inicio);
            parametros[4] = new SqlParameter("fim", Formacao.Fim);
            return parametros;
        }
        public void Excluir(int id, int idCurriculo)
        {
            string sql = "delete FormacaoAcademica where id =" + id + " idCurriculo="+idCurriculo;
            HelperDAO.ExecutaSQL(sql, null);
        }
        /*public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from jogos";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }*/
        private FormacaoViewModel MontarFormacao(DataRow registro)
        {
            FormacaoViewModel a = new FormacaoViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.IdCurriculo = Convert.ToInt32(registro["idCurriculo"]);
            a.Instituicao = registro["instituicao"].ToString();
            a.Inicio = Convert.ToDateTime(registro["inicio"]);
            a.Fim = Convert.ToDateTime(registro["fim"]);
            a.Acoes = EnumAcoes.Nada;
            return a;
        }

        public List<FormacaoViewModel> Consulta(int idCurriculo)
        {
            List<FormacaoViewModel> Lista = new List<FormacaoViewModel>();
            string sql = "select * from FormacaoAcademica where idCurriculo = " + idCurriculo;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
            {
                for (int n = 0; n < tabela.Rows.Count; n++)
                    Lista.Add(MontarFormacao(tabela.Rows[n]));
                return Lista;
            }

        }

    }
}
