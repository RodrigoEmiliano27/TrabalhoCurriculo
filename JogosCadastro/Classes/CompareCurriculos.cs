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
            VerificarIdiomas();
            VerificarHabilidades();


        }
        /// <summary>
        /// Verifica se alguma informação básica do curriculo foi alterada... se for retorna true se houver alteração
        /// </summary>
        /// <returns>true se detectar alteração e false se não detectar</returns>
        private bool CadastroCurriculoChanged()
        {
            string face = CurriculoNovo.Facebook != null ? CurriculoNovo.Facebook : "";
            string inst = CurriculoNovo.Instagram != null ? CurriculoNovo.Instagram : "";
            string link = CurriculoNovo.Linkdin != null ? CurriculoNovo.Linkdin : "";
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
            else if (CurriculoVelho.Numero_Endereco != CurriculoNovo.Numero_Endereco)
                return true;
            else if (CurriculoVelho.Facebook != face)
                return true;
            else if (CurriculoVelho.Linkdin != link)
                return true;
            else if (CurriculoVelho.Instagram != inst)
                return true;
            else if (CurriculoVelho.SobreMim != CurriculoNovo.SobreMim)
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
            //Remove dados não válidos           
            for (int n = 0; n < CurriculoNovo.Formacao.Count; n++)
            {
                if (CurriculoNovo.Formacao[n].Descricao == null && CurriculoNovo.Formacao[n].Instituicao == null)
                    CurriculoNovo.Formacao.RemoveAt(n);
            }
            //Se o curriculo estava sem formação academica todos os dados devem ser inseridos
            if (CurriculoVelho.Formacao.Count == 0 && CurriculoNovo.Formacao.Count > 0)
            {
                foreach (FormacaoViewModel form in CurriculoNovo.Formacao)
                {
                    form.IdCurriculo = CurriculoVelho.Id;
                    formDao.Inserir(form);

                }
                    

                return;
            }
            //Verifica uma exclusão de formação ou uma alteração
            foreach (FormacaoViewModel form in CurriculoVelho.Formacao)
            {
                foreach (FormacaoViewModel form2 in CurriculoNovo.Formacao)
                {
                    if (form2.Id == form.Id)
                    {
                        if(form2.IdCurriculo==-1)
                            formDao.Excluir(form2.Id, form.IdCurriculo);
                        else if (FormacaoChanged(form, form2))
                            formDao.Alterar(form2);
                        break;
                        
                    }
                }
            }
            achou = false;
            //verifica inserção de dados
            foreach (FormacaoViewModel form2 in CurriculoNovo.Formacao)
            {
                if (form2.Id == 0)
                {
                    form2.IdCurriculo = CurriculoVelho.Id;
                    formDao.Inserir(form2);
                }                            

            }
        }
        /// <summary>
        /// Verifica os idiomas, se dados novos foram inseridos, alterados e excluidos e faz as correções necessárias
        /// </summary>
        private void VerificarIdiomas()
        {
            bool achou = false;
            IdiomaDAO IdiDao = new IdiomaDAO();
            //Remove dados não válidos           
            for (int n = 0; n < CurriculoNovo.Idiomas.Count; n++)
            {
                if (CurriculoNovo.Idiomas[n].Idioma == null )
                    CurriculoNovo.Idiomas.RemoveAt(n);
            }
            //Se o curriculo estava sem Idiomas  todos os dados devem ser inseridos
            if (CurriculoVelho.Idiomas.Count == 0 && CurriculoNovo.Idiomas.Count > 0)
            {
                foreach (IdiomaViewModel form in CurriculoNovo.Idiomas)
                {
                    form.IdCurriculo = CurriculoVelho.Id;
                    IdiDao.Inserir(form);
                }

                return;
            }
            //Verifica uma exclusão de Idiomas ou uma alteração
            foreach (IdiomaViewModel form in CurriculoVelho.Idiomas)
            {
                foreach (IdiomaViewModel form2 in CurriculoNovo.Idiomas)
                {
                    if (form2.Id == form.Id)
                    {
                        if (form2.IdCurriculo == -1)
                            IdiDao.Excluir(form2.Id, form.IdCurriculo);
                        else if (IdioChanged(form, form2))
                            IdiDao.Alterar(form2);
                        break;

                    }
                }
                // o Id não foi encontrado logo terá que ser excluido

            }
            //verifica inserção de dados
            foreach (IdiomaViewModel form2 in CurriculoNovo.Idiomas)
            {
                if (form2.Id == 0)
                {
                    form2.IdCurriculo = CurriculoVelho.Id;
                    IdiDao.Inserir(form2);
                }

            }

        }
        /// <summary>
        /// Verifica as Habilidades, se dados novos foram inseridos, alterados e excluidos e faz as correções necessárias
        /// </summary>
        private void VerificarHabilidades()
        {
            bool achou = false;
            HabilidadesDAO HabDao = new HabilidadesDAO();
            //Remove dados não válidos           
            for (int n = 0; n < CurriculoNovo.Habilidades.Count; n++)
            {
                if (CurriculoNovo.Habilidades[n].Descricao == null)
                    CurriculoNovo.Habilidades.RemoveAt(n);
            }
            //Se o curriculo estava sem Idiomas  todos os dados devem ser inseridos
            if (CurriculoVelho.Habilidades.Count == 0 && CurriculoNovo.Habilidades.Count > 0)
            {
                foreach (HabilidadesViewModel form in CurriculoNovo.Habilidades)
                {
                    form.IdCurriculo = CurriculoVelho.Id;
                    HabDao.Inserir(form);
                }

                return;
            }
            //Verifica uma exclusão de Habilidades ou uma alteração
            foreach (HabilidadesViewModel form in CurriculoVelho.Habilidades)
            {
                foreach (HabilidadesViewModel form2 in CurriculoNovo.Habilidades)
                {
                    if (form2.Id == form.Id)
                    {
                        if (form2.IdCurriculo == -1)
                            HabDao.Excluir(form2.Id, form.IdCurriculo);
                        else if (HabChanged(form, form2))
                            HabDao.Alterar(form2);
                        break;

                    }
                }
               
            }
            //verifica inserção de dados
            foreach (HabilidadesViewModel form2 in CurriculoNovo.Habilidades)
            {
                if (form2.Id == 0)
                {
                    form2.IdCurriculo = CurriculoVelho.Id;
                    HabDao.Inserir(form2);
                }

            }
        }

        /// <summary>
        /// Verifica se uma formação academica é diferente
        /// </summary>
        /// <param name="fold">formacao antiga</param>
        /// <param name="fnew"> formacao a ser comparada</param>
        /// <returns>retorna true se as formações forem diferentes</returns>
        private bool FormacaoChanged(FormacaoViewModel fold, FormacaoViewModel fnew)
        {
            if (fold.Descricao!= fnew.Descricao)
                return true;
            else if (fold.Instituicao != fnew.Instituicao)
                return true;
            else if (fold.Inicio != fnew.Inicio)
                return true;
            else if (fold.Fim != fnew.Fim)
                return true;

            return false;
        }
        /// <summary>
        /// Verifica se um idioma é diferente de outro
        /// </summary>
        /// <param name="Iold">idioma antigo</param>
        /// <param name="Inew">idioma nova</param>
        /// <returns> retorna true se os idiomas forem diferentes</returns>
        private bool IdioChanged(IdiomaViewModel Iold, IdiomaViewModel Inew)
        {
            if (Iold.Idioma != Inew.Idioma)
                return true;
            else if (Iold.Nivel != Inew.Nivel)
                return true;

            return false;
        }
        /// <summary>
        /// Verifica se as habilidades são diferentes
        /// </summary>
        /// <param name="old"></param>
        /// <param name="novo"></param>
        /// <returns></returns>
        private bool HabChanged(HabilidadesViewModel old, HabilidadesViewModel novo)
        {
            if (old.Descricao != novo.Descricao)
                return true;
            else if (old.Nivel != novo.Nivel)
                return true;

            return false;
        }
    }
}


