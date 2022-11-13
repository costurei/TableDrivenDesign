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
                .Include(p => p.EntregaPrevisaoHistoricos)
                .ToListAsync();

            return list;
        }

        public static async Task<Pedido> GetPedidoById(this MinhaLojaDbContext db, int id)
        {
            var item = await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Servico)
                .Include(p => p.EntregaPrevisaoHistoricos)
                .SingleOrDefaultAsync(p => p.Id == id);

            return item;
        }
    }
}
