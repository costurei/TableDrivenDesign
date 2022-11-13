using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MinhaLoja.Data
{
    public class MinhaLojaDbContextFactory : IDesignTimeDbContextFactory<MinhaLojaDbContext>
    {
        public MinhaLojaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MinhaLojaDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MinhaLoja.TableDrivenDesign;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new MinhaLojaDbContext(optionsBuilder.Options);
        }
    }
}
