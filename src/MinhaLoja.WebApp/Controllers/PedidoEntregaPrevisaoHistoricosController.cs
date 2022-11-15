using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaLoja.Data;
using MinhaLoja.Models;
using MinhaLoja.Services;

namespace MinhaLoja.Controllers;

public class PedidoEntregaPrevisaoHistoricosController : Controller
{
    private readonly MinhaLojaDbContext _db;

    public PedidoEntregaPrevisaoHistoricosController(MinhaLojaDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _db.GetPedidoEntregaPrevisaoHistoricos();

        return View(list);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedidoEntregaPrevisaoHistorico = await _db.GetPedidoEntregaPrevisaoHistoricoById(id.Value);

        if (pedidoEntregaPrevisaoHistorico == null)
        {
            return NotFound();
        }

        return View(pedidoEntregaPrevisaoHistorico);
    }

    public async Task<IActionResult> Create(int? pedidoId)
    {
        var pedidoEntregaPrevisaoHistorico = new PedidoEntregaPrevisaoHistorico();

        int? clienteId;

        if (pedidoId.HasValue)
        {
            var pedido = await _db.Pedidos.FindAsync(pedidoId.Value);

            if (pedido == null)
            {
                clienteId = null;

                ViewData["PedidoId"] = new HashSet<SelectListItem>();
            }
            else
            {
                clienteId = pedido.ClienteId;

                ViewData["PedidoId"] = new SelectList(_db.Pedidos.Where(p => p.ClienteId == clienteId), "Id", "Descricao");
            }

            pedidoEntregaPrevisaoHistorico.PedidoId = pedidoId.Value;

            ViewData["Parent"] = "Pedido";
        }
        else
        {
            clienteId = null;

            ViewData["PedidoId"] = new SelectList(_db.Pedidos, "Id", "Descricao");
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Nome", clienteId);

        return View(pedidoEntregaPrevisaoHistorico);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PedidoId,Data,Valor")] PedidoEntregaPrevisaoHistorico pedidoEntregaPrevisaoHistorico, string? parent, int? clienteId, string? command)
    {
        if (command == "SelectCliente")
        {
            ModelState.Clear();

            if (clienteId.HasValue)
            {
                ViewData["PedidoId"] = new SelectList(_db.Pedidos.Where(p => p.ClienteId == clienteId), "Id", "Descricao");
            }
        }
        else
        {
            if (ModelState.IsValid)
            {
                _db.Add(pedidoEntregaPrevisaoHistorico);

                await _db.SaveChangesAsync();

                if (parent == "Pedido")
                {
                    return RedirectToAction("Details", "Pedidos", new { id = pedidoEntregaPrevisaoHistorico.PedidoId });
                }

                return RedirectToAction(nameof(Index));
            }
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Nome", clienteId);

        ViewData["Parent"] = parent;

        return View(pedidoEntregaPrevisaoHistorico);
    }

    public async Task<IActionResult> Edit(int? id, string? parent, string? from)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedidoEntregaPrevisaoHistorico = await _db.PedidoEntregaPrevisaoHistoricos.FindAsync(id);

        if (pedidoEntregaPrevisaoHistorico == null)
        {
            return NotFound();
        }

        int? clienteId;

        var pedido = await _db.Pedidos.FindAsync(pedidoEntregaPrevisaoHistorico.PedidoId);

        if (pedido == null)
        {
            return Problem();
        }
        else
        {
            clienteId = pedido.ClienteId;
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Nome", clienteId);

        ViewData["PedidoId"] = new SelectList(_db.Pedidos.Where(p => p.ClienteId == clienteId), "Id", "Descricao", pedidoEntregaPrevisaoHistorico.PedidoId);

        ViewData["Parent"] = parent;

        ViewData["From"] = from;

        return View(pedidoEntregaPrevisaoHistorico);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,Data,Valor,RowVersion")] PedidoEntregaPrevisaoHistorico pedidoEntregaPrevisaoHistorico, string? parent, string? from, int? clienteId, string? command)
    {
        if (id != pedidoEntregaPrevisaoHistorico.Id)
        {
            return NotFound();
        }

        if (command == "SelectCliente")
        {
            ModelState.Clear();

            if (clienteId.HasValue)
            {
                ViewData["PedidoId"] = new SelectList(_db.Pedidos.Where(p => p.ClienteId == clienteId), "Id", "Descricao", pedidoEntregaPrevisaoHistorico.PedidoId);
            }
        }
        else
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(pedidoEntregaPrevisaoHistorico);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.ExistsEntity<PedidoEntregaPrevisaoHistorico>(pedidoEntregaPrevisaoHistorico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if (parent == "Pedido")
                {
                    return RedirectToAction("Details", "Pedidos", new { id = pedidoEntregaPrevisaoHistorico.PedidoId });
                }

                if (from == "Details")
                {
                    return RedirectToAction(nameof(Details), new { id });
                }

                return RedirectToAction(nameof(Index));
            }
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Nome", clienteId);

        ViewData["Parent"] = parent;

        ViewData["From"] = from;

        return View(pedidoEntregaPrevisaoHistorico);
    }

    public async Task<IActionResult> Delete(int? id, string? parent)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedidoEntregaPrevisaoHistorico = await _db.GetPedidoEntregaPrevisaoHistoricoById(id.Value);

        if (pedidoEntregaPrevisaoHistorico == null)
        {
            return NotFound();
        }

        ViewData["Parent"] = parent;

        return View(pedidoEntregaPrevisaoHistorico);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, string? parent)
    {
        var pedidoEntregaPrevisaoHistorico = await _db.PedidoEntregaPrevisaoHistoricos.FindAsync(id);

        if (pedidoEntregaPrevisaoHistorico == null)
        {
            return NotFound();
        }

        _db.PedidoEntregaPrevisaoHistoricos.Remove(pedidoEntregaPrevisaoHistorico);

        await _db.SaveChangesAsync();

        if (parent == "Pedido")
        {
            return RedirectToAction("Details", "Pedidos", new { id = pedidoEntregaPrevisaoHistorico.PedidoId });
        }

        return RedirectToAction(nameof(Index));
    }
}
