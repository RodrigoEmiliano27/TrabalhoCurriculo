using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoCurriculo.Models
{
    public class FormacaoViewModel
    {

        public FormacaoViewModel()
        {
            this.Inicio = new DateTime(1970, 1, 1);
            this.Fim = new DateTime(1970, 1, 1);
        }

        public int Id { get; set; }
        public int IdCurriculo { get; set; }
        public string Instituicao { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

    }
}
