using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaLoja.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePrefixo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    NomePrimeiro = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    NomeSegundo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    NomeSufixo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EntregaPrevisaoData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntregaData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    SinalValor = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoEntregaPrevisaoHistoricos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoEntregaPrevisaoHistoricos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoEntregaPrevisaoHistoricos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Endereco", "NomePrefixo", "NomePrimeiro", "NomeSegundo", "NomeSufixo", "Telefone" },
                values: new object[,]
                {
                    { 1, null, null, "Cliente A", null, "Ref 1", null },
                    { 2, null, null, "Cliente B", null, "Ref 1", null },
                    { 3, null, null, "Cliente B", null, "Ref 2", null },
                    { 4, null, null, "Cliente C", null, "Ref 1", null }
                });

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "Id", "Descricao", "Valor" },
                values: new object[,]
                {
                    { 1, "Serviço 01", 15.00m },
                    { 2, "Serviço 02", 10.00m }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "ClienteId", "Data", "Descricao", "EntregaData", "EntregaPrevisaoData", "Pago", "ServicoId", "SinalValor", "Valor" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 2, 28, 19, 53, 0, 0, DateTimeKind.Unspecified), "Pedido 01", new DateTime(2021, 3, 3, 17, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 4, 19, 53, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 15.00m },
                    { 2, 2, new DateTime(2021, 8, 30, 20, 30, 0, 0, DateTimeKind.Unspecified), "Pedido 01", new DateTime(2021, 9, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 20, 30, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0.00m },
                    { 3, 3, new DateTime(2021, 11, 13, 9, 10, 0, 0, DateTimeKind.Unspecified), "Pedido 01", new DateTime(2021, 11, 12, 18, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 13, 9, 10, 0, 0, DateTimeKind.Unspecified), false, 1, 0m, 7.00m },
                    { 4, 3, new DateTime(2021, 11, 13, 9, 10, 0, 0, DateTimeKind.Unspecified), "Pedido 02", null, new DateTime(2021, 11, 17, 9, 10, 0, 0, DateTimeKind.Unspecified), false, 2, 0m, 10.00m }
                });

            migrationBuilder.InsertData(
                table: "PedidoEntregaPrevisaoHistoricos",
                columns: new[] { "Id", "Data", "PedidoId" },
                values: new object[] { 1, new DateTime(2021, 3, 2, 19, 53, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "PedidoEntregaPrevisaoHistoricos",
                columns: new[] { "Id", "Data", "PedidoId" },
                values: new object[] { 2, new DateTime(2021, 11, 13, 9, 10, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "PedidoEntregaPrevisaoHistoricos",
                columns: new[] { "Id", "Data", "PedidoId" },
                values: new object[] { 3, new DateTime(2021, 11, 15, 9, 10, 0, 0, DateTimeKind.Unspecified), 4 });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoEntregaPrevisaoHistoricos_PedidoId",
                table: "PedidoEntregaPrevisaoHistoricos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ServicoId",
                table: "Pedidos",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoEntregaPrevisaoHistoricos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Servicos");
        }
    }
}
