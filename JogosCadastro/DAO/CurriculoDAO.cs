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
            "SET DATEFORMAT dmy  " +
            "insert into Curriculos(nome, telefone,cpf, email,DataNascimento, cargoPretendido,Cep,rua" +
            ",Bairro,Cidade,Estado,Numero,Facebook,Linkdin,Instagram,SobreMim)" +
            "values ( @nome, @telefone,@cpf, @email,@DataNascimento, @cargoPretendido,@Cep,@rua,@Bairro" +
            ",@Cidade,@Estado,@Numero,@Facebook,@Linkdin,@Instagram,@SobreMim) ";
            
            HelperDAO.ExecutaSQL(sql, CriaParametros(Curriculo));
        }
        public void Alterar(CurriculoViewModel Curriculo)
        {
            string sql =
            "SET DATEFORMAT dmy  "+
            "update Curriculos set nome = @nome, " +
            "telefone = @telefone, " +
            "cpf = @cpf, " +
            "email = @email," +
            "DataNascimento = @DataNascimento," +
            "cargoPretendido = @cargoPretendido, " +
            "Cep = @Cep, " +
            "rua = @rua, " +
            "Bairro = @Bairro, " +
            "Cidade = @Cidade, " +
            "Estado = @Estado, " +
            "Numero = @Numero, " +
            "Facebook = @Facebook, " +
            "Linkdin = @Linkdin, " +
            "Instagram = @Instagram, " +
            "SobreMim = @SobreMim " +
            "where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Curriculo));
        }
        public void AlterarImagem(byte[] Imagem,int id)
        {

            string sql =
            "SET ANSI_WARNINGS  OFF " +
            "update Curriculos set Imagem = @Imagem " +
            "where id = @id " + 
            "SET ANSI_WARNINGS ON ";
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("Imagem", Imagem !=null ? Imagem: new byte[] { });
            parametros[1] = new SqlParameter("id", id);
            HelperDAO.ExecutaSQL(sql, parametros);
        }

        private SqlParameter[] CriaParametros(CurriculoViewModel Curriculo)
        {
            object imgByte = Curriculo.ImagemEmByte;
            if (imgByte == null)
                imgByte = new byte[] { };

            SqlParameter[] parametros = new SqlParameter[18];
            parametros[0] = new SqlParameter("nome", Curriculo.Nome);
            parametros[1] = new SqlParameter("telefone", Curriculo.Telefone);
            parametros[2] = new SqlParameter("cpf", Curriculo.CPF);
            parametros[3] = new SqlParameter("email", Curriculo.Email);
            parametros[4] = new SqlParameter("DataNascimento", Curriculo.Nascimento);
            parametros[5] = new SqlParameter("cargoPretendido", Curriculo.Cargo_Pretendido);
            parametros[6] = new SqlParameter("Cep", Curriculo.CEP);
            parametros[7] = new SqlParameter("rua", Curriculo.Rua);
            parametros[8] = new SqlParameter("Bairro", Curriculo.Bairro);
            parametros[9] = new SqlParameter("Cidade", Curriculo.Cidade);
            parametros[10] = new SqlParameter("Estado", Curriculo.Estado);
            parametros[11] = new SqlParameter("Numero", Curriculo.Numero_Endereco);
            parametros[12] = new SqlParameter("Facebook", Curriculo.Facebook != null ? Curriculo.Facebook:"");
            parametros[13] = new SqlParameter("Linkdin", Curriculo.Linkdin != null ? Curriculo.Linkdin : "");
            parametros[14] = new SqlParameter("Instagram", Curriculo.Instagram != null ? Curriculo.Instagram : "");
            parametros[15] = new SqlParameter("SobreMim", Curriculo.SobreMim != null ? Curriculo.SobreMim : "");
            parametros[16] = new SqlParameter("Imagem", imgByte);

            parametros[17] = new SqlParameter("id", Curriculo.Id);

            return parametros;
        }
        public void Excluir(int id)
        {
            string sql = "EXEC DeletarCurriculo @idCurriculo = " + id;
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
            a.Nascimento =Convert.ToDateTime(registro["DataNascimento"].ToString());
            a.Cargo_Pretendido = registro["cargoPretendido"].ToString();
            a.CEP = registro["Cep"].ToString();
            a.Rua = registro["rua"].ToString();
            a.Bairro = registro["Bairro"].ToString();
            a.Cidade = registro["Cidade"].ToString();
            a.Estado = registro["Estado"].ToString();
            a.Numero_Endereco = Convert.ToInt32(registro["Numero"]);
            a.Facebook = registro["Facebook"].ToString();
            a.Linkdin = registro["Linkdin"].ToString();
            a.Instagram = registro["Instagram"].ToString();
            a.SobreMim = registro["SobreMim"].ToString();

            if (registro["imagem"] != DBNull.Value)
                a.ImagemEmByte = registro["imagem"] as byte[];
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
