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

        var pagamento = await _db.GetPedidoEntregaPrevisaoHistoricoById(id.Value);

        if (pagamento == null)
        {
            return NotFound();
        }

        return View(pagamento);
    }

    public async Task<IActionResult> Create(int? pedidoId)
    {
        var pagamento = new PedidoEntregaPrevisaoHistorico();

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

            pagamento.PedidoId = pedidoId.Value;

            ViewData["Parent"] = "Pedido";
        }
        else
        {
            clienteId = null;
        }

        ViewData["PedidoId"] = new SelectList(_db.Pedidos, "Id", "Descricao");

        return View(pagamento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PedidoId,Data,Valor")] PedidoEntregaPrevisaoHistorico pagamento, string? parent, int? clienteId, string? command)
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
                _db.Add(pagamento);

                await _db.SaveChangesAsync();

                if (parent == "Pedido")
                {
                    return RedirectToAction("Details", "Pedido", new { id = pagamento.PedidoId });
                }

                return RedirectToAction(nameof(Index));
            }
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Descricao", clienteId);

        ViewData["Parent"] = parent;

        return View(pagamento);
    }

    public async Task<IActionResult> Edit(int? id, string? parent, string? from)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pagamento = await _db.PedidoEntregaPrevisaoHistoricos.FindAsync(id);

        if (pagamento == null)
        {
            return NotFound();
        }

        int? clienteId;

        var pedido = await _db.Pedidos.FindAsync(pagamento.PedidoId);

        if (pedido == null)
        {
            return Problem();
        }
        else
        {
            clienteId = pedido.ClienteId;
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Descricao", clienteId);

        ViewData["PedidoId"] = new SelectList(_db.Pedidos.Where(p => p.ClienteId == clienteId), "Id", "Descricao", pagamento.PedidoId);

        ViewData["Parent"] = parent;

        ViewData["From"] = from;

        return View(pagamento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,Data,Valor,RowVersion")] PedidoEntregaPrevisaoHistorico pagamento, string? parent, string? from, int? clienteId, string? command)
    {
        if (id != pagamento.Id)
        {
            return NotFound();
        }

        if (command == "SelectCliente")
        {
            ModelState.Clear();

            if (clienteId.HasValue)
            {
                ViewData["PedidoId"] = new SelectList(_db.Pedidos.Where(p => p.ClienteId == clienteId), "Id", "Descricao", pagamento.PedidoId);
            }
        }
        else
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(pagamento);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.ExistsEntity<PedidoEntregaPrevisaoHistorico>(pagamento.Id))
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
                    return RedirectToAction("Details", "Pedido", new { id = pagamento.PedidoId });
                }

                if (from == "Details")
                {
                    return RedirectToAction(nameof(Details), new { id });
                }

                return RedirectToAction(nameof(Index));
            }
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Descricao", clienteId);

        ViewData["Parent"] = parent;

        ViewData["From"] = from;

        return View(pagamento);
    }

    public async Task<IActionResult> Delete(int? id, string? parent)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pagamento = await _db.GetPedidoEntregaPrevisaoHistoricoById(id.Value);

        if (pagamento == null)
        {
            return NotFound();
        }

        ViewData["Parent"] = parent;

        return View(pagamento);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, string? parent)
    {
        var pagamento = await _db.PedidoEntregaPrevisaoHistoricos.FindAsync(id);

        if (pagamento == null)
        {
            return NotFound();
        }

        _db.PedidoEntregaPrevisaoHistoricos.Remove(pagamento);

        await _db.SaveChangesAsync();

        if (parent == "Pedido")
        {
            return RedirectToAction("Details", "Pedido", new { id = pagamento.PedidoId });
        }

        return RedirectToAction(nameof(Index));
    }
}
