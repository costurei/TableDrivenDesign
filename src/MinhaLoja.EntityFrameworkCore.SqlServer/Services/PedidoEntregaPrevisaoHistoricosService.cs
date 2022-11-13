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
                    .ThenInclude(p => p.Cliente)
                .Include(p => p.Pedido)
                    .ThenInclude(p => p.Servico)
                .ToListAsync();

            return list;
        }

        public static async Task<PedidoEntregaPrevisaoHistorico> GetPedidoEntregaPrevisaoHistoricoById(this MinhaLojaDbContext db, int id)
        {
            var item = await db.PedidoEntregaPrevisaoHistoricos
                .Include(p => p.Pedido)
                    .ThenInclude(p => p.Cliente)
                .Include(p => p.Pedido)
                    .ThenInclude(p => p.Servico)
                .SingleOrDefaultAsync(p => p.Id == id);

            return item;
        }
    }
}
