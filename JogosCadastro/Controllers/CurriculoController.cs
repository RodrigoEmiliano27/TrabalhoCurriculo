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
            JogoDAO dao = new JogoDAO();
            List<JogoViewModel> lista = dao.Listagem();
            return View(lista);
        }

        public IActionResult Create(int id)
        {
            JogoViewModel jogo = new JogoViewModel();
            jogo.Data_Aquisicao = DateTime.Now;

            JogoDAO dao = new JogoDAO();
            jogo.Id = dao.ProximoId();

            return View("Form", jogo);
        }
        public IActionResult Edit(int id)
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                JogoViewModel jogo = dao.Consulta(id);
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

        public IActionResult Salvar(JogoViewModel jogo)
        {          
            try
            {
                JogoDAO dao = new JogoDAO();
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
                JogoDAO dao = new JogoDAO();
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
