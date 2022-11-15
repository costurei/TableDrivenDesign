using MinhaLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace MinhaLoja.Data
{
    public class MinhaLojaDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<PedidoEntregaPrevisaoHistorico> PedidoEntregaPrevisaoHistoricos { get; set; } = default!;
        public DbSet<Servico> Servicos { get; set; } = default!;

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

            //modelBuilder.Entity<Cliente>().HasData(
            //    new Cliente { Id = 1, NomePrimeiro = "Cliente A", NomeSufixo = "Ref 1" },
            //    new Cliente { Id = 2, NomePrimeiro = "Cliente B", NomeSufixo = "Ref 1" },
            //    new Cliente { Id = 3, NomePrimeiro = "Cliente B", NomeSufixo = "Ref 2" },
            //    new Cliente { Id = 4, NomePrimeiro = "Cliente C", NomeSufixo = "Ref 1" }
            //);

            //modelBuilder.Entity<Servico>().HasData(
            //    new Servico { Id = 1, Descricao = "Serviço 01", Valor = 15.00m },
            //    new Servico { Id = 2, Descricao = "Serviço 02", Valor = 10.00m }
            //);

            //modelBuilder.Entity<Pedido>().HasData(
            //    new Pedido { Id = 1, ClienteId = 1, Data = new DateTime(2021, 02, 28, 19, 53, 0), ServicoId = 1, Descricao = "Pedido 01", EntregaPrevisaoData = new DateTime(2021, 03, 04, 19, 53, 0), EntregaData = new DateTime(2021, 03, 03, 17, 15, 0), Valor = 15.00m, SinalValor = 0, Pago = true },
            //    new Pedido { Id = 2, ClienteId = 2, Data = new DateTime(2021, 08, 30, 20, 30, 0), ServicoId = 1, Descricao = "Pedido 01", EntregaPrevisaoData = new DateTime(2021, 09, 01, 20, 30, 0), EntregaData = new DateTime(2021, 09, 01, 18, 30, 0), Valor = 0.00m, SinalValor = 0, Pago = true },
            //    new Pedido { Id = 3, ClienteId = 3, Data = new DateTime(2021, 11, 13, 09, 10, 0), ServicoId = 1, Descricao = "Pedido 01", EntregaPrevisaoData = new DateTime(2021, 11, 13, 09, 10, 0), EntregaData = new DateTime(2021, 11, 12, 18, 10, 0), Valor = 7.00m, SinalValor = 0, Pago = false },
            //    new Pedido { Id = 4, ClienteId = 3, Data = new DateTime(2021, 11, 13, 09, 10, 0), ServicoId = 2, Descricao = "Pedido 02", EntregaPrevisaoData = new DateTime(2021, 11, 17, 09, 10, 0), EntregaData = null, Valor = 10.00m, SinalValor = 0, Pago = false }
            //);

            //modelBuilder.Entity<PedidoEntregaPrevisaoHistorico>().HasData(
            //    new PedidoEntregaPrevisaoHistorico { Id = 1, PedidoId = 1, Data = new DateTime(2021, 03, 02, 19, 53, 0) },
            //    new PedidoEntregaPrevisaoHistorico { Id = 2, PedidoId = 2, Data = new DateTime(2021, 11, 13, 09, 10, 0) },
            //    new PedidoEntregaPrevisaoHistorico { Id = 3, PedidoId = 4, Data = new DateTime(2021, 11, 15, 09, 10, 0) }
            //);
        }
    }
}
