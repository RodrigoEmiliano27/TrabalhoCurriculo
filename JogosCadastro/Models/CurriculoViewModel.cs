using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogosCadastro.Models
{
    public class CurriculoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cargo_Pretendido { get; set; }
        public int Categoria { get; set; }
        public DateTime Data_Aquisicao { get; set; }
    }
}
