﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhaLoja.Data;

#nullable disable

namespace MinhaLoja.Data.Migrations
{
    [DbContext(typeof(MinhaLojaDbContext))]
    partial class MinhaLojaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MinhaLoja.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Endereco")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Telefone")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Cliente A",
                            Referencia = "Ref 1"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Cliente B",
                            Referencia = "Ref 1"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Cliente B",
                            Referencia = "Ref 2"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Cliente C",
                            Referencia = "Ref 1"
                        });
                });

            modelBuilder.Entity("MinhaLoja.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("Valor")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("MinhaLoja.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1,
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Pedido 01",
                            ServicoId = 1,
                            Valor = 15.00m
                        },
                        new
                        {
                            Id = 2,
                            ClienteId = 2,
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Pedido 01",
                            ServicoId = 1,
                            Valor = 0.00m
                        },
                        new
                        {
                            Id = 3,
                            ClienteId = 3,
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Pedido 01",
                            ServicoId = 1,
                            Valor = 7.00m
                        },
                        new
                        {
                            Id = 4,
                            ClienteId = 3,
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Pedido 02",
                            ServicoId = 2,
                            Valor = 10.00m
                        });
                });

            modelBuilder.Entity("MinhaLoja.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("TipoId");

                    b.ToTable("Servicos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Serviço 01",
                            TipoId = 1,
                            Valor = 15.00m
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Serviço 02",
                            TipoId = 1,
                            Valor = 10.00m
                        });
                });

            modelBuilder.Entity("MinhaLoja.Models.ServicoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("ValorPadrao")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.ToTable("ServicoTipos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Tipo de Serviço 01",
                            ValorPadrao = 1.00m
                        });
                });

            modelBuilder.Entity("MinhaLoja.Models.Pagamento", b =>
                {
                    b.HasOne("MinhaLoja.Models.Pedido", "Pedido")
                        .WithMany("Pagamentos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("MinhaLoja.Models.Pedido", b =>
                {
                    b.HasOne("MinhaLoja.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinhaLoja.Models.Servico", "Servico")
                        .WithMany("Pedidos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("MinhaLoja.Models.Servico", b =>
                {
                    b.HasOne("MinhaLoja.Models.ServicoTipo", "Tipo")
                        .WithMany("Servicos")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("MinhaLoja.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("MinhaLoja.Models.Pedido", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("MinhaLoja.Models.Servico", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("MinhaLoja.Models.ServicoTipo", b =>
                {
                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}