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
                .Include(p => p.Pedidos)
                    .ThenInclude(p => p.Servico)
                .ToListAsync();

            return list;
        }

        public static async Task<Cliente> GetClienteById(this MinhaLojaDbContext db, int id)
        {
            var item = await db.Clientes
                .Include(p => p.Pedidos)
                    .ThenInclude(p => p.Servico)
                .SingleOrDefaultAsync(p => p.Id == id);

            return item;
        }
    }
}
