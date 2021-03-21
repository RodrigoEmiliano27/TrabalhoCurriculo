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

            VerificarFormacaoAcademica();


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
            bool achou = false;
            FormacaoDAO formDao = new FormacaoDAO();
            //Se o curriculo estava sem formação academica todos os dados devem ser inseridos
            if (CurriculoVelho.Formacao.Count == 0 && CurriculoNovo.Formacao.Count > 0)
            {
                foreach (FormacaoViewModel form in CurriculoNovo.Formacao)
                    formDao.Inserir(form);

                return;
            }
            //Verifica uma exclusão de formação
            foreach (FormacaoViewModel form in CurriculoVelho.Formacao)
            {
                foreach (FormacaoViewModel form2 in CurriculoNovo.Formacao)
                {
                    if (form2.Id == form.Id)
                    {
                        achou = true;
                        if (FormacaoChanged(form, form2))
                            formDao.Alterar(form);
                        break;
                    }      
                }
                // o Id não foi encontrado logo terá que ser excluido
                if (!achou)
                    formDao.Excluir(form.Id, form.IdCurriculo);
                achou = false;     
            }
            achou = false;
            //verifica inserção de dados
            foreach (FormacaoViewModel form2 in CurriculoNovo.Formacao)
            {
                foreach (FormacaoViewModel form in CurriculoVelho.Formacao)
                {
                    if (form2.Id == form.Id)
                    {
                        achou = true;
                        break;
                    }
                }
                form2.IdCurriculo = CurriculoNovo.Id;
                if (!achou)
                    formDao.Inserir(form2);

            }
        }
        private bool FormacaoChanged(FormacaoViewModel fold,FormacaoViewModel fnew)
        {
            if (fold.Descricao == fnew.Descricao)
                return true;
            else if (fold.Instituicao == fnew.Instituicao)
                return true;
            else if (fold.Inicio == fnew.Inicio)
                return true;
            else if (fold.Fim == fnew.Fim)
                return true;

            return false;
        }
    }
}
