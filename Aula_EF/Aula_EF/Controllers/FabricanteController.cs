
using Aula_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExemploEF.Controllers
{
    public class FabricanteController : Controller
    {
        public Context context;

        public FabricanteController(Context ctx)
        {
            context = ctx;
        }

        // lista todos os fabricantes
        public IActionResult Index()
        {
            return View(context.Fabricantes);
        }

        // exibe o formulário
        public IActionResult Create()
        {
            return View();
        }

        // salva no banco
        [HttpPost]
        public IActionResult Create(Fabricante fabricante)
        {
            context.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //  exibe um fabricante pelo id
        public IActionResult Details(int id)
        {
            var fabricante = context.Fabricantes
                .Include(f => f.Produtos) //  carrega os produtos
                .FirstOrDefault(f => f.FabricanteId == id);

            return View(fabricante);
        }

        //  carrega o fabricante para edição
        public IActionResult Edit(int id)
        {
            var fabricante = context.Fabricantes.Find(id);
            return View(fabricante);
        }

        //  salva as alterações
        [HttpPost]
        public IActionResult Edit(Fabricante fabricante)
        {
            context.Entry(fabricante).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //  exibe confirmação
        public IActionResult Delete(int id)
        {
            var fabricante = context.Fabricantes
                .FirstOrDefault(f => f.FabricanteId == id);
            return View(fabricante);
        }

        //  remove do banco
        [HttpPost]
        public IActionResult Delete(Fabricante fabricante)
        {
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
