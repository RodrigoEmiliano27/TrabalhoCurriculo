using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoCurriculo.Models
{
    public class FormacaoViewModel
    {
        public int Id { get; set; }
        public string Instituicao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
