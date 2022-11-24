using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaLoja.Data;
using MinhaLoja.Models;
using MinhaLoja.Services;

namespace MinhaLoja.Controllers;

public class ServicoPrecoHistoricosController : Controller
{
    private readonly MinhaLojaDbContext _db;

    public ServicoPrecoHistoricosController(MinhaLojaDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _db.GetServicoPrecoHistoricos();

        return View(list);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servicoPrecoHistorico = await _db.GetServicoPrecoHistoricoById(id.Value);

        if (servicoPrecoHistorico == null)
        {
            return NotFound();
        }

        return View(servicoPrecoHistorico);
    }

    public async Task<IActionResult> Create(int? servicoId)
    {
        var servicoPrecoHistorico = new ServicoPrecoHistorico();

        ViewData["ServicoId"] = new SelectList(_db.Servicos, "Id", "Descricao");

        if (servicoId.HasValue)
        {
            servicoPrecoHistorico.ServicoId = servicoId.Value;

            ViewData["Parent"] = "Servico";
        }

        return View(servicoPrecoHistorico);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ServicoId,Data,Valor")] ServicoPrecoHistorico servicoPrecoHistorico, string? parent)
    {
        if (ModelState.IsValid)
        {
            _db.Add(servicoPrecoHistorico);

            await _db.SaveChangesAsync();

            if (parent == "Servico")
            {
                return RedirectToAction("Details", "Servicos", new { id = servicoPrecoHistorico.ServicoId });
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["ServicoId"] = new SelectList(_db.Servicos, "Id", "Descricao", servicoPrecoHistorico.ServicoId);

        ViewData["Parent"] = parent;

        return View(servicoPrecoHistorico);
    }

    public async Task<IActionResult> Edit(int? id, string? parent, string? from)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servicoPrecoHistorico = await _db.ServicoPrecoHistoricos.FindAsync(id);

        if (servicoPrecoHistorico == null)
        {
            return NotFound();
        }

        ViewData["ServicoId"] = new SelectList(_db.Servicos, "Id", "Descricao", servicoPrecoHistorico.ServicoId);

        ViewData["Parent"] = parent;

        ViewData["From"] = from;

        return View(servicoPrecoHistorico);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ServicoId,Data,Valor,RowVersion")] ServicoPrecoHistorico servicoPrecoHistorico, string? parent, string? from)
    {
        if (id != servicoPrecoHistorico.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _db.Update(servicoPrecoHistorico);

                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ExistsEntity<ServicoPrecoHistorico>(servicoPrecoHistorico.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (parent == "Servico")
            {
                return RedirectToAction("Details", "Servicos", new { id = servicoPrecoHistorico.ServicoId });
            }

            if (from == "Details")
            {
                return RedirectToAction(nameof(Details), new { id });
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["ServicoId"] = new SelectList(_db.Servicos, "Id", "Descricao", servicoPrecoHistorico.ServicoId);

        ViewData["Parent"] = parent;

        ViewData["From"] = from;

        return View(servicoPrecoHistorico);
    }

    public async Task<IActionResult> Delete(int? id, string? parent)
    {
        if (id == null)
        {
            return NotFound();
        }

        var servicoPrecoHistorico = await _db.GetServicoPrecoHistoricoById(id.Value);

        if (servicoPrecoHistorico == null)
        {
            return NotFound();
        }

        ViewData["Parent"] = parent;

        return View(servicoPrecoHistorico);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, string? parent)
    {
        var servicoPrecoHistorico = await _db.ServicoPrecoHistoricos.FindAsync(id);

        if (servicoPrecoHistorico == null)
        {
            return NotFound();
        }

        _db.ServicoPrecoHistoricos.Remove(servicoPrecoHistorico);

        await _db.SaveChangesAsync();

        if (parent == "Servico")
        {
            return RedirectToAction("Details", "Servicos", new { id = servicoPrecoHistorico.ServicoId });
        }

        return RedirectToAction(nameof(Index));
    }
}
