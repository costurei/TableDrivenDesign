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
                .Include(p => p.PrecoHistoricos)
                .Include(p => p.Pedidos)
                    .ThenInclude(p => p.Cliente)
                .ToListAsync();

            return list;
        }

        public static async Task<Servico> GetServicoById(this MinhaLojaDbContext db, int id)
        {
            var item = await db.Servicos
                .Include(p => p.PrecoHistoricos)
                .Include(p => p.Pedidos)
                    .ThenInclude(p => p.Cliente)
                .SingleOrDefaultAsync(p => p.Id == id);

            return item;
        }
    }
}
