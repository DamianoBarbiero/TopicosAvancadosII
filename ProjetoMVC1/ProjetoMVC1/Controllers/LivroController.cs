using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoMVC1.Controllers
{
    public class LivroController : Controller
    {
        public ActionResult Index()
        {
            bdlivroEntities context = new bdlivroEntities();
            var lst = context.tb_livro.ToList();
            return View(lst);
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cadastrar() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(tb_livro livro) {
            if (ModelState.IsValid) {
                bdlivroEntities context = new bdlivroEntities();
                context.tb_livro.Add(livro);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        public ActionResult Editar(int id) {
            bdlivroEntities context = new bdlivroEntities();
            return View(context.tb_livro.First(l => l.id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(tb_livro livro)
        {
            if (ModelState.IsValid)
            {
                bdlivroEntities context = new bdlivroEntities();
                tb_livro li = context.tb_livro.First(l => l.id == livro.id);
                li.nome = livro.nome;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        public ActionResult Detalhe(int id) {
            return View(new bdlivroEntities().tb_livro.First(l => l.id == id));
        }

        public ActionResult Excluir(int id) {
            return View(new bdlivroEntities().tb_livro.First(l => l.id == id));
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmaExcluir(int id) {
            bdlivroEntities context = new bdlivroEntities();
            tb_livro livro = context.tb_livro.First(l => l.id == id);
            context.tb_livro.Remove(livro);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}