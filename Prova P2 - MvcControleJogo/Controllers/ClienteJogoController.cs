using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcControleJogo.Models;

namespace MvcControleJogo.Controllers
{
    public class ClienteJogoController : Controller
    {
        private readonly MvcClienteContext _context;

        public ClienteJogoController(MvcClienteContext context)
        {
            _context = context;
        }

        // GET: ClienteJogo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteJogo.Include(localizacao => localizacao.NomeClienteFK).Include(localizacao => localizacao.NomeJogoFK).ToListAsync());
        }

        // GET: ClienteJogo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteJogo = await _context.ClienteJogo.Include(localizacao => localizacao.NomeClienteFK).Include(localizacao => localizacao.NomeJogoFK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clienteJogo == null)
            {
                return NotFound();
            }

            return View(clienteJogo);
        }

        // GET: ClienteJogo/Create
        public IActionResult Create()
        {
            ViewData["Cliente"] = new SelectList(_context.Cliente.ToList(), "NomeClienteFK").Items;
            ViewData["Jogos"] = new SelectList(_context.Jogos.ToList(), "NomeJogoFK").Items;
            return View();
        }

        // POST: ClienteJogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, NomeClienteFK, NomeJogoFK")] ClienteJogo clienteJogo, IFormCollection collection)
        {
            int ncfkk = Convert.ToInt16(collection["NomeClienteFK"]);
            int njfkk = Convert.ToInt16(collection["NomeJogoFK"]);

            if (ModelState.IsValid)
            {
                var cl = await _context.Cliente.FindAsync(ncfkk);
                clienteJogo.NomeClienteFK = cl; 

                var jog = await _context.Jogos.FindAsync(njfkk);
                clienteJogo.NomeJogoFK = jog; 

                _context.Add(clienteJogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteJogo);
        }

        // GET: ClienteJogo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteJogo = await _context.ClienteJogo.FindAsync(id);
            if (clienteJogo == null)
            {
                return NotFound();
            }
            return View(clienteJogo);
        }

        // POST: ClienteJogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, NomeClienteFK, NomeJogoFK")] ClienteJogo clienteJogo)
        {
            if (id != clienteJogo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteJogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteJogoExists(clienteJogo.ID))
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
            return View(clienteJogo);
        }

        // GET: ClienteJogo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteJogo = await _context.ClienteJogo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clienteJogo == null)
            {
                return NotFound();
            }

            return View(clienteJogo);
        }

        // POST: ClienteJogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteJogo = await _context.ClienteJogo.FindAsync(id);
            _context.ClienteJogo.Remove(clienteJogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteJogoExists(int id)
        {
            return _context.ClienteJogo.Any(e => e.ID == id);
        }
    }
}
