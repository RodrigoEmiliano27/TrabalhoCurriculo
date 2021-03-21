using TrabalhoCurriculo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Models;

namespace TrabalhoCurriculo.DAO
{
    public class CurriculoDAO
    {
        public void Inserir(CurriculoViewModel Curriculo)
        {
            string sql =
            "insert into Curriculos( nome, telefone,cpf, email, cargoPretendido,Cep,rua,Bairro,Cidade,Estado)" +
            "values ( @nome, @telefone,@cpf, @email, @cargoPretendido,@Cep,@rua,@Bairro,@Cidade,@Estado)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Curriculo));
        }
        public void Alterar(CurriculoViewModel Curriculo)
        {
            string sql =
            "update Curriculos set nome = @nome, " +
            "telefone = @telefone, " +
            "cpf = @cpf, " +
            "email = @email," +
            "cargoPretendido = @cargoPretendido"+
            "Cep = @Cep, " +
            "rua = @rua, " +
            "Bairro = @Bairro, " +
            "Cidade = @Cidade, " +
            "Estado = @Estado, " +
            "where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Curriculo));
        }
        private SqlParameter[] CriaParametros(CurriculoViewModel Curriculo)
        {
            SqlParameter[] parametros = new SqlParameter[10];
            parametros[0] = new SqlParameter("nome", Curriculo.Nome);
            parametros[1] = new SqlParameter("telefone", Curriculo.Telefone);
            parametros[2] = new SqlParameter("cpf", Curriculo.CPF);
            parametros[3] = new SqlParameter("email", Curriculo.Email);
            parametros[4] = new SqlParameter("cargoPretendido", Curriculo.Cargo_Pretendido);
            parametros[5] = new SqlParameter("Cep", Curriculo.CEP);
            parametros[6] = new SqlParameter("rua", Curriculo.Rua);
            parametros[7] = new SqlParameter("Bairro", Curriculo.Bairro);
            parametros[8] = new SqlParameter("Cidade", Curriculo.Cidade);
            parametros[9] = new SqlParameter("Estado", Curriculo.Estado);
            
            return parametros;
        }
        public void Excluir(int id)
        {
            string sql = "delete Curriculos where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }
       public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from Curriculos";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
        private CurriculoViewModel MontaCurriculoSimples(DataRow registro)
        {
            CurriculoViewModel a = new CurriculoViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Nome = registro["nome"].ToString();
            a.Telefone = registro["telefone"].ToString();
            a.CPF = registro["cpf"].ToString();
            a.Email = registro["email"].ToString();
            a.Cargo_Pretendido = registro["cargoPretendido"].ToString();
            a.CEP = registro["Cep"].ToString();
            a.Rua = registro["rua"].ToString();
            a.Bairro = registro["Bairro"].ToString();
            a.Cidade = registro["Cidade"].ToString();
            a.Estado = registro["Estado"].ToString();
            return a;
        }

        public CurriculoViewModel Consulta(int id)
        {
            CurriculoViewModel c = new CurriculoViewModel();
            string sql = "select * from Curriculos where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
            {
                c= MontaCurriculoSimples(tabela.Rows[0]);
                c.Formacao = (new FormacaoDAO()).Consulta(c.Id);
                c.Idiomas = (new IdiomaDAO()).Consulta(c.Id);
                c.Habilidades = (new HabilidadesDAO()).Consulta(c.Id);
                return c;
                

            }
                
        }
        public List<CurriculoViewModel> Listagem()
        {
            List<CurriculoViewModel> lista = new List<CurriculoViewModel>();
            string sql = "select * from Curriculos order by Id";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaCurriculoSimples(registro));
            return lista;
        }
        
    }
}
