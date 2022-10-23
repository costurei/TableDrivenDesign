using MinhaLoja.Data;
using MinhaLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaLoja.Services
{
    public static class PedidoEntregaPrevisaoHistoricosService
    {
        public static async Task<List<PedidoEntregaPrevisaoHistorico>> GetPedidoEntregaPrevisaoHistoricos(this MinhaLojaDbContext db)
        {
            var list = await db.PedidoEntregaPrevisaoHistoricos
                .Include(p => p.Pedido)
                    .ThenInclude(p=>p.Cliente)
                .ToListAsync();

            return list;
        }

        public static async Task<List<PedidoEntregaPrevisaoHistorico>> GetPedidoEntregaPrevisaoHistoricosByPedidoId(this MinhaLojaDbContext db, int pedidoId)
        {
            var list = await db.PedidoEntregaPrevisaoHistoricos
                .Include(p => p.Pedido)
                    .ThenInclude(p => p.Cliente)
                .Where(p => p.PedidoId == pedidoId)
                .ToListAsync();

            return list;
        }

        public static async Task<PedidoEntregaPrevisaoHistorico> GetPedidoEntregaPrevisaoHistorico(this MinhaLojaDbContext db, int id)
        {
            var item = await db.PedidoEntregaPrevisaoHistoricos
                .Include(p => p.Pedido)
                    .ThenInclude(p => p.Cliente)
                .SingleOrDefaultAsync(p => p.Id == id);

            return item;
        }
    }
}
