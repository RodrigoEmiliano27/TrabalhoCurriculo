using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Models;

namespace TrabalhoCurriculo.DAO
{
    public class EnderecoDAO
    {
        public void Inserir(EnderecoViewModel Endereco)
        {
            string sql =
            "insert into Enderecos(idCurriculo, Cep, rua, Bairro,Cidade,Estado)" +
            "values (@idCurriculo @Cep, @rua, @Bairro,@Cidade,@Estado)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Endereco));
        }
        public void Alterar(EnderecoViewModel Endereco)
        {
            string sql =
            "update Enderecos set Cep = @Cep, " +
            "rua = @rua, " +
            "Bairro = @Bairro," +
            "Cidade = @Cidade," +
            "Estado = @Estado," +
            "Where idCurriculo= @idCurriculo";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Endereco));
        }
        private SqlParameter[] CriaParametros(EnderecoViewModel Endereco)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("idCurriculo", Endereco.IdCurriculo);
            parametros[1] = new SqlParameter("Cep", Endereco.CEP);
            parametros[2] = new SqlParameter("rua", Endereco.Rua);
            parametros[3] = new SqlParameter("Bairro", Endereco.Bairro);
            parametros[4] = new SqlParameter("Cidade", Endereco.Cidade);
            parametros[5] = new SqlParameter("Estado", Endereco.Estado);
            return parametros;
        }
        public void Excluir(int idCurriculo)
        {
            string sql = "delete Enderecos where idCurriculo =" + idCurriculo;
            HelperDAO.ExecutaSQL(sql, null);
        }
        /*public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from jogos";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }*/
        private EnderecoViewModel MontaEndereco(DataRow registro)
        {
            EnderecoViewModel a = new EnderecoViewModel();
            a.IdCurriculo = Convert.ToInt32(registro["idCurriculo"]);
            a.CEP = registro["Cep"].ToString();
            a.Rua = registro["rua"].ToString();
            a.Bairro = registro["Bairro"].ToString();
            a.Cidade = registro["Cidade"].ToString();
            a.Estado = registro["Estado"].ToString();
            return a;
        }

        public EnderecoViewModel Consulta(int idCurriculo)
        {
            EnderecoViewModel endereco = new EnderecoViewModel();
            string sql = "select * from Enderecos where idCurriculo = " + idCurriculo;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
               return MontaEndereco(tabela.Rows[0]);


        }
    }
}
