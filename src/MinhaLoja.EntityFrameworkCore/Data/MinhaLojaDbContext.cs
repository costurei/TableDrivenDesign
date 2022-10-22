using MinhaLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaLoja.Data
{
    public class MinhaLojaDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<Pagamento> Pagamentos { get; set; } = default!;
        public DbSet<Servico> Servicos { get; set; } = default!;
        public DbSet<ServicoTipo> ServicoTipos { get; set; } = default!;

        public MinhaLojaDbContext(DbContextOptions<MinhaLojaDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //if (optionsBuilder.IsConfigured == false)
            //{
            //    optionsBuilder.UseInMemoryDatabase("Design");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nome = "Cliente A", Referencia = "Ref 1" },
                new Cliente { Id = 2, Nome = "Cliente B", Referencia = "Ref 1" },
                new Cliente { Id = 3, Nome = "Cliente B", Referencia = "Ref 2" },
                new Cliente { Id = 4, Nome = "Cliente C", Referencia = "Ref 1" }
            );

            modelBuilder.Entity<ServicoTipo>().HasData(
                new ServicoTipo { Id = 1, Nome = "Tipo de Serviço 01", ValorPadrao = 1.00m }
            );

            modelBuilder.Entity<Servico>().HasData(
                new Servico { Id = 1, TipoId = 1, Descricao = "Serviço 01", Valor = 15.00m },
                new Servico { Id = 2, TipoId = 1, Descricao = "Serviço 02", Valor = 10.00m }
            );

            modelBuilder.Entity<Pedido>().HasData(
                new Pedido { Id = 1, ClienteId = 1, ServicoId = 1, Descricao = "Pedido 01", Valor = 15.00m },
                new Pedido { Id = 2, ClienteId = 2, ServicoId = 1, Descricao = "Pedido 01", Valor = 0.00m },
                new Pedido { Id = 3, ClienteId = 3, ServicoId = 1, Descricao = "Pedido 01", Valor = 7.00m },
                new Pedido { Id = 4, ClienteId = 3, ServicoId = 2, Descricao = "Pedido 02", Valor = 10.00m }
            );
        }
    }
}
