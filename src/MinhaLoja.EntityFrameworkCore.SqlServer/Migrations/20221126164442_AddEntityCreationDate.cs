using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaLoja.Migrations
{
    public partial class AddEntityCreationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Servicos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ServicoPrecoHistoricos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PedidoEntregaPrevisaoHistoricos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ServicoPrecoHistoricos");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PedidoEntregaPrevisaoHistoricos");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Clientes");
        }
    }
}
