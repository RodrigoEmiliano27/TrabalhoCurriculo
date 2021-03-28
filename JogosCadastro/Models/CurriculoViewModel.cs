using Microsoft.AspNetCore.Http;
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
            this.Id = -1;
        }
        /// <summary>
        /// Imagem recebida do form pelo controller
        /// </summary>
        public IFormFile Imagem { get; set; }
        /// <summary>
        /// Imagem em bytes pronta para ser salva
        /// </summary>
        public byte[] ImagemEmByte { get; set; }
        /// <summary>
        /// Imagem usada para ser enviada ao form no formato para ser exibida
        /// </summary>
        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cargo_Pretendido { get; set; }
        public string CEP { get; set; }
        public int Numero_Endereco { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Facebook { get; set; }
        public string Linkdin { get; set; }
        public string Instagram { get; set; }
        public string SobreMim { get; set; }
        public List<IdiomaViewModel> Idiomas { get; set; }
        public List<FormacaoViewModel> Formacao { get; set; }
        public List<HabilidadesViewModel> Habilidades { get; set; }
    }
}
