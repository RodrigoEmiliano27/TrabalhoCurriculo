using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.DAO;
using TrabalhoCurriculo.Models;

namespace TrabalhoCurriculo.Classes
{
    public  class CompareCurriculos
    {
        private CurriculoViewModel CurriculoVelho;
        private CurriculoViewModel CurriculoNovo;
        public CompareCurriculos(CurriculoViewModel old, CurriculoViewModel novo)
        {
            CurriculoVelho = old;
            CurriculoNovo = novo;
        }
        public void CompararCurriculo()
        {
            CurriculoDAO dao = new CurriculoDAO();
            if (CadastroCurriculoChanged())
                dao.Alterar(CurriculoNovo);


        }
        private bool CadastroCurriculoChanged()
        {
            if (CurriculoVelho.Nome != CurriculoNovo.Nome)
                return true;
            else if (CurriculoVelho.Telefone != CurriculoNovo.Telefone)
                return true;
            else if (CurriculoVelho.CPF != CurriculoNovo.CPF)
                return true;
            else if (CurriculoVelho.Email != CurriculoNovo.Email)
                return true;
            else if (CurriculoVelho.Cargo_Pretendido != CurriculoNovo.Cargo_Pretendido)
                return true;
            else if (CurriculoVelho.CEP != CurriculoNovo.CEP)
                return true;
            else if (CurriculoVelho.Rua != CurriculoNovo.Rua)
                return true;
            else if (CurriculoVelho.Bairro != CurriculoNovo.Bairro)
                return true;
            else if (CurriculoVelho.Cidade != CurriculoNovo.Cidade)
                return true;
            else if (CurriculoVelho.Estado != CurriculoNovo.Estado)
                return true;

            return false;
        }
        private void VerificarFormacaoAcademica()
        {
            FormacaoDAO formDao = new FormacaoDAO();
            //Se o curriculo 
            if (CurriculoVelho.Formacao.Count == 0 && CurriculoNovo.Formacao.Count > 0)
            {
                foreach (FormacaoViewModel form in CurriculoNovo.Formacao)
                    formDao.Inserir(form);

                return;
            }
            foreach (FormacaoViewModel form in CurriculoVelho.Formacao)
            {
                
            }
        }
    }
}
