using JogosCadastro.DAO;
using JogosCadastro.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogosCadastro.Controllers
{
    public class CurriculoController : Controller
    {
        public IActionResult Index()
        {
            CurriculoDAO dao = new CurriculoDAO();
            List<CurriculoViewModel> lista = dao.Listagem();
            return View(lista);
        }

        public IActionResult Create(int id)
        {
            CurriculoViewModel jogo = new CurriculoViewModel();
            jogo.Data_Aquisicao = DateTime.Now;

            CurriculoDAO dao = new CurriculoDAO();
            jogo.Id = dao.ProximoId();

            return View("Form", jogo);
        }
        public IActionResult Edit(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel jogo = dao.Consulta(id);
                if (jogo == null)
                    return RedirectToAction("index");
                else
                    return View("Exibir", jogo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Salvar(CurriculoViewModel jogo)
        {          
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                if (dao.Consulta(jogo.Id) == null)
                    dao.Inserir(jogo);
                else
                    dao.Alterar(jogo);

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
