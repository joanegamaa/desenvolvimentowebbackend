using Exemplo1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exemplo1_MVC.Controllers
{
    public class CategoriaController : Controller
    {
        public static IList<Categoria> categorias = new List<Categoria>() {
            new Categoria() {
                CategoriaId = 1,
                Nome = "Vestuario"
            },
            new Categoria() {
                CategoriaId = 2,
                Nome = "Eletronicos"
            },
            new Categoria() {
                CategoriaId = 3,
                Nome = "Utilidades Domésticas"
            },
        };

        public IActionResult Index()

        {
            //gera uma view(exibição HTML
            //com todas as categorias (cat), cl
            return View(categorias.OrderBy(cat => cat.CategoriaId ));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Categoria categoria)
        {

            categorias.Add(categoria); //adiciona a nova categoria a lista, busca o úlyimo Id e incrementa
            // 1 para cada categoria
            categoria.CategoriaId = categorias.Select(cat => cat.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)

        {
            //retorna uma view com os dados da categoria cujo id
            //foi passado como parâmetro
            return View(categorias.Where(cat => cat.CategoriaId == id).First());
        }
    }
}