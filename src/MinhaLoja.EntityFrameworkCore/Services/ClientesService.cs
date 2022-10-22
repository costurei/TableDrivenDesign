using MinhaLoja.Data;
using MinhaLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaLoja.Services
{
    public static class ClientesService
    {
        public static async Task<List<Cliente>> GetClientes(this MinhaLojaDbContext db)
        {
            var list = await db.Clientes
                .ToListAsync();

            return list;
        }

        public static async Task<Cliente> GetCliente(this MinhaLojaDbContext db, int id)
        {
            var item = await db.Clientes
                .SingleOrDefaultAsync(p => p.Id == id);

            item.Pedidos = await db.GetPedidosByClienteId(id);

            return item;
        }
    }
}
