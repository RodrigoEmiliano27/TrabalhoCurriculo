using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Models;

namespace TrabalhoCurriculo.Models
{
    public class CurriculoViewModel
    {
        public CurriculoViewModel()
        {
            Formacao = new List<FormacaoViewModel>();
            Idiomas = new List<IdiomaViewModel>();
            Habilidades = new List<HabilidadesViewModel>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cargo_Pretendido { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public List<IdiomaViewModel> Idiomas { get; set; }
        public List<FormacaoViewModel> Formacao { get; set; }
        public List<HabilidadesViewModel> Habilidades { get; set; }
    }
}
