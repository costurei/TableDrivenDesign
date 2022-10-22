using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaLoja.Data;
using MinhaLoja.Models;
using MinhaLoja.Services;

namespace MinhaLoja.Controllers
{
    public class ClientesController : Controller
    {
        private readonly MinhaLojaDbContext _db;

        public ClientesController(MinhaLojaDbContext db)
        {
            _db = db;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
              return View(await _db.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _db.GetCliente(id.Value);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            var cliente = new Cliente();

            return View(cliente);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Referencia,Telefone,Endereco,Id,RowVersion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Add(cliente);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Referencia,Telefone,Endereco,Id,RowVersion")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(cliente);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _db.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Clientes == null)
            {
                return Problem("Entity set 'MinhaLojaDbContext.Clientes'  is null.");
            }
            var cliente = await _db.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _db.Clientes.Remove(cliente);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return _db.Clientes.Any(e => e.Id == id);
        }
    }
}
