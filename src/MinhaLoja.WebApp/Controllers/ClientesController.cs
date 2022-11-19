using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaLoja.Data;
using MinhaLoja.Models;
using MinhaLoja.Services;

namespace MinhaLoja.Controllers;

public class ClientesController : Controller
{
    private readonly MinhaLojaDbContext _db;

    public ClientesController(MinhaLojaDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _db.GetClientes();

        return View(list);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _db.Clientes == null)
        {
            return NotFound();
        }

        var cliente = await _db.GetClienteById(id.Value);

        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    public IActionResult Create()
    {
        var cliente = new Cliente();

        return View(cliente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NomePrefixo,NomePrimeiro,NomeSegundo,NomeSufixo,Telefone,Endereco")] Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            _db.Add(cliente);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(cliente);
    }

    public async Task<IActionResult> Edit(int? id, string? from)
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

        ViewData["From"] = from;

        return View(cliente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NomePrefixo,NomePrimeiro,NomeSegundo,NomeSufixo,Telefone,Endereco,RowVersion")] Cliente cliente, string? from)
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
                if (!_db.ExistsEntity<Cliente>(cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (from == "Details")
            {
                return RedirectToAction(nameof(Details), new { id });
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["From"] = from;

        return View(cliente);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cliente = await _db.GetClienteById(id.Value);

        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cliente = await _db.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        _db.Clientes.Remove(cliente);

        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
