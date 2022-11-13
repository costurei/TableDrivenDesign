using MinhaLoja.Data;
using MinhaLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaLoja.Services
{
    public static class PedidosService
    {
        public static async Task<List<Pedido>> GetPedidos(this MinhaLojaDbContext db)
        {
            var list = await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .ToListAsync();

            return list;
        }

        public static async Task<List<Pedido>> GetPedidosByClienteId(this MinhaLojaDbContext db, int clienteId)
        {
            var list = await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();

            return list;
        }

        public static async Task<List<Pedido>> GetPedidosByServicoId(this MinhaLojaDbContext db, int servicoId)
        {
            var list = await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .Where(p => p.ServicoId == servicoId)
                .ToListAsync();

            return list;
        }

        public static async Task<Pedido> GetPedido(this MinhaLojaDbContext db, int id)
        {
            var item = await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .SingleOrDefaultAsync(p => p.Id == id);

            item.EntregaPrevisaoHistoricos = await db.GetPedidoEntregaPrevisaoHistoricosByPedidoId(id);

            return item;
        }
    }
}
