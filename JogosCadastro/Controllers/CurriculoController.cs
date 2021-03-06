using TrabalhoCurriculo.DAO;
using TrabalhoCurriculo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCurriculo.Classes;
using Microsoft.AspNetCore.Http;
using System.IO;
//using RestSharp;

namespace TrabalhoCurriculo.Controllers
{
    public class CurriculoController : Controller
    {

        private char IdiomaSelecionado = 'P';

        public IActionResult Index()
        {
            ViewBag.Idioma = getSelectedLanguage();


            CurriculoDAO dao = new CurriculoDAO();
            List<CurriculoViewModel> lista = dao.Listagem();

            return View(lista);
        }

        public IActionResult Create(int id)
        {
            ViewBag.Idioma = getSelectedLanguage();


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
                ViewBag.Idioma = getSelectedLanguage();

                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel cur = dao.Consulta(id);
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
            int id;
            try
            {

                ViewBag.Idioma = getSelectedLanguage();
                CurriculoDAO dao = new CurriculoDAO();
                FormacaoDAO fdao = new FormacaoDAO();
                IdiomaDAO Idao = new IdiomaDAO();
                HabilidadesDAO Hdao = new HabilidadesDAO();
                //cur.Nascimento = Convert.ToDateTime("10/07/1997");
                cur.ImagemEmByte = ConvertImageToByte(cur.Imagem);
                if (dao.Consulta(cur.Id) == null)
                {
                    id = dao.ProximoId();
                    dao.Inserir(cur);
                    if(cur.ImagemEmByte!=null)
                        dao.AlterarImagem(cur.ImagemEmByte, id);
                    //garante que vai estar no ID correto
                    id = dao.ProximoId() - 1;
                    foreach (FormacaoViewModel f in cur.Formacao)
                    {
                        if (f.Descricao != null && f.Instituicao != null)
                        {
                            f.IdCurriculo = id;
                            fdao.Inserir(f);
                        }
                    }

                    foreach (IdiomaViewModel d in cur.Idiomas)
                    {
                        if (d.Idioma != null)
                        {
                            d.IdCurriculo = id;
                            Idao.Inserir(d);
                        }
                       
                    }

                    foreach (HabilidadesViewModel h in cur.Habilidades)
                    {
                        if (h.Descricao != null)
                        {
                            h.IdCurriculo = id;
                            Hdao.Inserir(h);
                        }
                      
                    }

                }
                else
                {
                    CompareCurriculos Compare = new CompareCurriculos(dao.Consulta(cur.Id), cur);
                    Compare.CompararCurriculo();
                    if (cur.StatusImg == "Editar")
                    {

                        dao.AlterarImagem(cur.ImagemEmByte, cur.Id);
                    }
                }

                return RedirectToAction("index");






            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }

        }
        
        /// <summary>
        /// Converte a imagem recebida no form em um vetor de bytes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
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

        public IActionResult Language(string language,string lastPage)
        {

            WriteCookies(language);
            /*if (Request.Cookies["Curriculo_Idioma"] != null)
            {
                ViewBag.Idioma = Request.Cookies["Curriculo_Idioma"];
            }
            else
            {
                ViewBag.Idioma = 'P';
            }*/

            if(lastPage == "Main")
            {
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("Edit");
            }


        }

        private string getSelectedLanguage()
        {
            if (Request.Cookies["Curriculo_Idioma"] != null)
            {
                return Request.Cookies["Curriculo_Idioma"];
            }

            return "P";
        }

        public IActionResult Sobre()
        {
            return View("Sobre");
        }


        public IActionResult Exibir(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel cur = dao.Consulta(id);
                ViewBag.Idioma = getSelectedLanguage();
                if (cur == null)
                    return RedirectToAction("index");
                else
                    return View("Exibir", cur);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public void WriteCookies(string idioma)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            options.IsEssential = true;

            if (Request.Cookies["Curriculo_Idioma"] != null)
                Response.Cookies.Delete("Curriculo_Idioma");

            Response.Cookies.Append("Curriculo_Idioma", idioma,options);
            
        }


 

       
    }
}
