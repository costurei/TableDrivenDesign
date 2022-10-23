using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaLoja.Data;
using MinhaLoja.Models;
using MinhaLoja.Services;

namespace MinhaLoja.Controllers;

public class ServicosController : Controller
{
    private readonly MinhaLojaDbContext _db;

    public ServicosController(MinhaLojaDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _db.GetServicos();

        return View(list);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servico = await _db.GetServico(id.Value);

        if (servico == null)
        {
            return NotFound();
        }

        return View(servico);
    }

    public IActionResult Create()
    {
        var servico = new Servico();

        return View(servico);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Descricao,Valor")] Servico servico)
    {
        if (ModelState.IsValid)
        {
            _db.Add(servico);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(servico);
    }

    public async Task<IActionResult> Edit(int? id, string? from)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servico = await _db.Servicos.FindAsync(id);

        if (servico == null)
        {
            return NotFound();
        }

        ViewData["From"] = from;

        return View(servico);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Valor,RowVersion")] Servico servico, string? parent, string? from)
    {
        if (id != servico.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _db.Update(servico);

                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ExistsEntity<Servico>(servico.Id))
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

        return View(servico);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servico = await _db.GetServico(id.Value);

        if (servico == null)
        {
            return NotFound();
        }

        return View(servico);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var servico = await _db.Servicos.FindAsync(id);

        if (servico == null)
        {
            return NotFound();
        }

        _db.Servicos.Remove(servico);

        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
