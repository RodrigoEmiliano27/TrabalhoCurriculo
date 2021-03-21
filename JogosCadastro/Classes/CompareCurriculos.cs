using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.DAO;
using TrabalhoCurriculo.Models;

namespace TrabalhoCurriculo.Classes
{
    public class CompareCurriculos
    {
        //Classe para comparar os dados de dois curriculos, um sendo o velho, como estava antes e o outro um novo e como deve ficar

        private CurriculoViewModel CurriculoVelho;
        private CurriculoViewModel CurriculoNovo;
        public CompareCurriculos(CurriculoViewModel old, CurriculoViewModel novo)
        {
            CurriculoVelho = old;
            CurriculoNovo = novo;
        }
        /// <summary>
        /// Compara um Curriculo antigo e um novo para determinar as mudanças que devem ser realizadas
        /// </summary>
        public void CompararCurriculo()
        {
            CurriculoDAO dao = new CurriculoDAO();
            if (CadastroCurriculoChanged())
                dao.Alterar(CurriculoNovo);

            VerificarFormacaoAcademica();


        }
        /// <summary>
        /// Verifica se alguma informação básica do curriculo foi alterada... se for retorna true se houver alteração
        /// </summary>
        /// <returns>true se detectar alteração e false se não detectar</returns>
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
        /// <summary>
        /// Verifica a formação academica, se dados novos foram inseridos, alterados e excluidos e faz as correções necessárias
        /// </summary>
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
        private void VerificarIdiomas()
        {
            bool achou = false;
            IdiomaDAO IdiDao = new IdiomaDAO();
            //Se o curriculo estava sem Idiomas  todos os dados devem ser inseridos
            if (CurriculoVelho.Idiomas.Count == 0 && CurriculoNovo.Idiomas.Count > 0)
            {
                foreach (IdiomaViewModel form in CurriculoNovo.Idiomas)
                    IdiDao.Inserir(form);

                return;
            }
            //Verifica uma exclusão de Idiomas
            foreach (IdiomaViewModel form in CurriculoVelho.Idiomas)
            {
                foreach (IdiomaViewModel form2 in CurriculoNovo.Idiomas)
                {
                    if (form2.Id == form.Id)
                    {
                        achou = true;
                        if (IdioChanged(form, form2))
                            IdiDao.Alterar(form);
                        break;
                    }
                }
                // o Id não foi encontrado logo terá que ser excluido
                if (!achou)
                    IdiDao.Excluir(form.Id, form.IdCurriculo);
                achou = false;
            }
            achou = false;
            //verifica inserção de dados
            foreach (IdiomaViewModel form2 in CurriculoNovo.Idiomas)
            {
                foreach (IdiomaViewModel form in CurriculoVelho.Idiomas)
                {
                    if (form2.Id == form.Id)
                    {
                        achou = true;
                        break;
                    }
                }
                form2.IdCurriculo = CurriculoNovo.Id;
                if (!achou)
                    IdiDao.Inserir(form2);

            }

        }
        private void VerificarHabilidades()
        {
            bool achou = false;
            HabilidadesDAO HabDao = new HabilidadesDAO();
            //Se o curriculo estava sem Idiomas  todos os dados devem ser inseridos
            if (CurriculoVelho.Habilidades.Count == 0 && CurriculoNovo.Habilidades.Count > 0)
            {
                foreach (HabilidadesViewModel form in CurriculoNovo.Habilidades)
                    HabDao.Inserir(form);

                return;
            }
            //Verifica uma exclusão de Habilidades
            foreach (HabilidadesViewModel form in CurriculoVelho.Habilidades)
            {
                foreach (HabilidadesViewModel form2 in CurriculoNovo.Habilidades)
                {
                    if (form2.Id == form.Id)
                    {
                        achou = true;
                        if (HabChanged(form, form2))
                            HabDao.Alterar(form);
                        break;
                    }
                }
                // o Id não foi encontrado logo terá que ser excluido
                if (!achou)
                    HabDao.Excluir(form.Id, form.IdCurriculo);
                achou = false;
            }
            achou = false;
            //verifica inserção de dados
            foreach (HabilidadesViewModel form2 in CurriculoNovo.Habilidades)
            {
                foreach (HabilidadesViewModel form in CurriculoVelho.Habilidades)
                {
                    if (form2.Id == form.Id)
                    {
                        achou = true;
                        break;
                    }
                }
                form2.IdCurriculo = CurriculoNovo.Id;
                if (!achou)
                    HabDao.Inserir(form2);

            }

        }


        private bool FormacaoChanged(FormacaoViewModel fold, FormacaoViewModel fnew)
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
        private bool IdioChanged(IdiomaViewModel Iold, IdiomaViewModel Inew)
        {
            if (Iold.Idioma == Inew.Idioma)
                return true;
            else if (Iold.Nivel == Inew.Nivel)
                return true;

            return false;
        }
        private bool HabChanged(HabilidadesViewModel old, HabilidadesViewModel novo)
        {
            if (old.Descricao == novo.Descricao)
                return true;
            else if (old.Nivel == novo.Nivel)
                return true;

            return false;
        }
    }
}


