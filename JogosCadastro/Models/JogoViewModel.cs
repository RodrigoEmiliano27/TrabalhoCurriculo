using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogosCadastro.Models
{
    public class JogoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor_Locacao { get; set; }
        public int Categoria { get; set; }
        public DateTime Data_Aquisicao { get; set; }
    }
}
