using MinhaLoja.Data;
using MinhaLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaLoja.Services
{
    public static class ServicoPrecoHistoricosService
    {
        public static async Task<List<ServicoPrecoHistorico>> GetServicoPrecoHistoricos(this MinhaLojaDbContext db)
        {
            var list = await db.ServicoPrecoHistoricos
                .Include(p => p.Servico)
                .ToListAsync();

            return list;
        }

        public static async Task<ServicoPrecoHistorico> GetServicoPrecoHistoricoById(this MinhaLojaDbContext db, int id)
        {
            var item = await db.ServicoPrecoHistoricos
                .Include(p => p.Servico)
                .SingleOrDefaultAsync(p => p.Id == id);

            return item;
        }
    }
}
