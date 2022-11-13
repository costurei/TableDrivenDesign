using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace MinhaLoja.Services;

public static class EntityService
{
    public static bool ExistsEntity<TEntity>(this DbContext db, int id)
        where TEntity : Entity
    {
        return db.Set<TEntity>().Any(e => e.Id == id);
    }
}
