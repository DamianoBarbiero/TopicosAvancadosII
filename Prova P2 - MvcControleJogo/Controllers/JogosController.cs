using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcControleJogo.Models;

namespace MvcControleJogo.Controllers
{
    public class JogosController : Controller
    {
        private readonly MvcClienteContext _context;

        public JogosController(MvcClienteContext context)
        {
            _context = context;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jogos.Include(localizacao => localizacao.NomeCategoriaFK).Include(localizacao => localizacao.NomePlataformaFK)
            .Include(localizacao => localizacao.DesenvolvedorFK).ToListAsync());
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos.Include(localizacao => localizacao.NomeCategoriaFK).Include(localizacao => localizacao.NomePlataformaFK)
            .Include(localizacao => localizacao.DesenvolvedorFK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria.ToList(), "NomeCategoria").Items;
            ViewData["Plataforma"] = new SelectList(_context.Plataforma.ToList(), "NomePlataforma").Items;
            ViewData["Empresa"] = new SelectList(_context.Empresa.ToList(), "NomeEmpresa").Items;
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, NomeJogo, NomeCategoriaFK, NomePlataformaFK, DesenvolvedorFK, AnoLanc")] Jogos jogos)
        {
            //string ncfk = Convert.ToString("NomeCategoriaFK");
            //string npfk = Convert.ToString("NomePlataformaFK");
            //string desenfk = Convert.ToString("DesenvolvedorFK");

            if (ModelState.IsValid)
            {
                //var cl = await _context.Categoria.FindAsync(ncfk);
               // var cls = await _context.Plataforma.FindAsync(npfk);
                //var cla = await _context.Empresa.FindAsync(desenfk);
                //jogos.NomeCategoriaFK = cl;
                //jogos.NomePlataformaFK = cls;
               // jogos.DesenvolvedorFK = cla;

                _context.Add(jogos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos.FindAsync(id);
            if (jogos == null)
            {
                return NotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, NomeJogo,  NomeCategoriaFK, NomePlataformaFK, DesenvolvedorFK, AnoLanc")] Jogos jogos)
        {
            if (id != jogos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogosExists(jogos.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jogos == null)
                {
                return NotFound();
            }

            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogos = await _context.Jogos.FindAsync(id);
            _context.Jogos.Remove(jogos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogosExists(int id)
        {
            return _context.Jogos.Any(e => e.ID == id);
        }
    }
}
