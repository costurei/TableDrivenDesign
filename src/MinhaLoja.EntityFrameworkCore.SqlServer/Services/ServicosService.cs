using MinhaLoja.Data;
using MinhaLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaLoja.Services
{
    public static class ServicosService
    {
        public static async Task<List<Servico>> GetServicos(this MinhaLojaDbContext db)
        {
            var list = await db.Servicos
                .ToListAsync();

            return list;
        }

        public static async Task<Servico> GetServico(this MinhaLojaDbContext db, int id)
        {
            var item = await db.Servicos
                .SingleOrDefaultAsync(p => p.Id == id);

            item.Pedidos = await db.GetPedidosByServicoId(id);

            return item;
        }
    }
}
