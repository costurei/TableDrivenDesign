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
                .ToListAsync();

            return list;
        }

        public static async Task<List<Pedido>> GetPedidosByClienteId(this MinhaLojaDbContext db, int clienteId)
        {
            var list = await db.Pedidos
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();

            return list;
        }

        public static async Task<Pedido> GetPedido(this MinhaLojaDbContext db, int id)
        {
            var item = await db.Pedidos
                .SingleOrDefaultAsync(p => p.Id == id);

            return item;
        }
    }
}
