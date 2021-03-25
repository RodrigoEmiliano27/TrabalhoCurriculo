using TrabalhoCurriculo.DAO;
using TrabalhoCurriculo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Classes;

namespace TrabalhoCurriculo.Controllers
{
    public class CurriculoController : Controller
    {
        CurriculoViewModel OldCurriculo = new CurriculoViewModel();
        public IActionResult Index()
        {
            CurriculoDAO dao = new CurriculoDAO();
            List<CurriculoViewModel> lista = dao.Listagem();
            return View(lista);
        }

        public IActionResult Create(int id)
        {
            CurriculoViewModel cur = new CurriculoViewModel();
            // jogo.Data_Aquisicao = DateTime.Now;
            

            CurriculoDAO dao = new CurriculoDAO();
            //jogo.Id = dao.ProximoId();

            return View("Form", cur);
            //return View("Exibir", cur);
        }
        public IActionResult Edit(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel cur = dao.Consulta(id);
                OldCurriculo = cur;
                if (cur == null)
                    return RedirectToAction("index");
                else
                    return View("Form", cur);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Salvar(CurriculoViewModel cur)
        {
            int id ;
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                FormacaoDAO fdao = new FormacaoDAO();
                IdiomaDAO Idao = new IdiomaDAO();
                HabilidadesDAO Hdao = new HabilidadesDAO();
                if (dao.Consulta(cur.Id) == null)
                {
                    id = dao.ProximoId();
                    dao.Inserir(cur);

                    foreach (FormacaoViewModel f in cur.Formacao)
                    {
                        f.IdCurriculo = id;
                        fdao.Inserir(f);
                    }

                    foreach (IdiomaViewModel d in cur.Idiomas)
                    {
                        d.IdCurriculo = id;
                        Idao.Inserir(d);
                    }

                    foreach (HabilidadesViewModel h in cur.Habilidades)
                    {
                        h.IdCurriculo = id;
                        Hdao.Inserir(h);
                    }

                }
                else
                {
                    CompareCurriculos Compare = new CompareCurriculos(OldCurriculo, cur);
                    Compare.CompararCurriculo();
                    dao.Alterar(cur);

                }

                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                dao.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
       
    }
}
