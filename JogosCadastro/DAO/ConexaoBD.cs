using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoCurriculo.DAO
{
    public static class ConexaoBD
    {
        private static string servername = @"DESKTOP-G71U68M\WINCCPLUSMIG2014";
       // private static string servername = @"LAPTOP-QI3AI4ST\SQLEXPRESS";
        private static string database = "CurriculosDudu";
        private static string server_login = "sa";
        private static string server_password = "123456";
        public static SqlConnection GetConexao()
        {
            string strCon = $"Data Source={servername};Initial Catalog={database};User ID={server_login};Password={server_password}";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }

}
