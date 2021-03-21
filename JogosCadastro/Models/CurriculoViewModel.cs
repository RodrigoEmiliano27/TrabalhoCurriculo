using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Models;

namespace JogosCadastro.Models
{
    public class CurriculoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cargo_Pretendido { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public IdiomaViewModel Idiomas { get; set; }
        public FormacaoViewModel Formacao { get; set; }

    }
}
