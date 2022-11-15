using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaLoja.Data;
using MinhaLoja.Models;
using MinhaLoja.Services;

namespace MinhaLoja.Controllers;

public class PedidosController : Controller
{
    private readonly MinhaLojaDbContext _db;

    public PedidosController(MinhaLojaDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _db.GetPedidos();

        return View(list);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedido = await _db.GetPedidoById(id.Value);

        if (pedido == null)
        {
            return NotFound();
        }

        return View(pedido);
    }

    public IActionResult Create(int? clienteId, int? servicoId)
    {
        var pedido = new Pedido();

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Nome");

        ViewData["ServicoId"] = new SelectList(_db.Servicos, "Id", "Descricao");

        if (clienteId.HasValue)
        {
            pedido.ClienteId = clienteId.Value;

            ViewData["Parent"] = "Cliente";
        }

        if (servicoId.HasValue)
        {
            pedido.ServicoId = servicoId.Value;

            ViewData["Parent"] = "Servico";
        }

        return View(pedido);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ClienteId,Data,ServicoId,Descricao,EntregaPrevisaoData,EntregaData,Valor,SinalValor,Pago")] Pedido pedido, string? parent)
    {
        if (ModelState.IsValid)
        {
            _db.Add(pedido);

            await _db.SaveChangesAsync();

            if (parent == "Cliente")
            {
                return RedirectToAction("Details", "Clientes", new { id = pedido.ClienteId });
            }

            if (parent == "Servico")
            {
                return RedirectToAction("Details", "Servicos", new { id = pedido.ServicoId });
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Nome", pedido.ClienteId);

        ViewData["ServicoId"] = new SelectList(_db.Servicos, "Id", "Descricao", pedido.ServicoId);

        ViewData["Parent"] = parent;

        return View(pedido);
    }

    public async Task<IActionResult> Edit(int? id, string? parent, string? from)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedido = await _db.Pedidos.FindAsync(id);

        if (pedido == null)
        {
            return NotFound();
        }

        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Nome", pedido.ClienteId);

        ViewData["ServicoId"] = new SelectList(_db.Servicos, "Id", "Descricao", pedido.ServicoId);

        ViewData["Parent"] = parent;

        ViewData["From"] = from;

        return View(pedido);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,Data,ServicoId,Descricao,EntregaPrevisaoData,EntregaData,Valor,SinalValor,Pago,RowVersion")] Pedido pedido, string? parent, string? from)
    {
        if (id != pedido.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _db.Update(pedido);

                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ExistsEntity<Pedido>(pedido.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (parent == "Cliente")
            {
                return RedirectToAction("Details", "Clientes", new { id = pedido.ClienteId });
            }

            if (parent == "Servico")
            {
                return RedirectToAction("Details", "Servicos", new { id = pedido.ServicoId });
            }

            if (from == "Details")
            {
                return RedirectToAction(nameof(Details), new { id });
            }

            return RedirectToAction(nameof(Index));
        }
        ViewData["ClienteId"] = new SelectList(_db.Clientes, "Id", "Nome", pedido.ClienteId);

        ViewData["ServicoId"] = new SelectList(_db.Servicos, "Id", "Descricao", pedido.ServicoId);

        ViewData["Parent"] = parent;

        ViewData["From"] = from;

        return View(pedido);
    }

    public async Task<IActionResult> Delete(int? id, string? parent)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedido = await _db.GetPedidoById(id.Value);

        if (pedido == null)
        {
            return NotFound();
        }

        ViewData["Parent"] = parent;

        return View(pedido);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, string? parent)
    {
        var pedido = await _db.Pedidos.FindAsync(id);

        if (pedido == null)
        {
            return NotFound();
        }

        _db.Pedidos.Remove(pedido);

        await _db.SaveChangesAsync();

        if (parent == "Cliente")
        {
            return RedirectToAction("Details", "Clientes", new { id = pedido.ClienteId });
        }

        if (parent == "Servico")
        {
            return RedirectToAction("Details", "Servicos", new { id = pedido.ServicoId });
        }

        return RedirectToAction(nameof(Index));
    }
}
