using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.WebApi.Migrations
{
    public partial class LocacoesMudanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEsperada",
                table: "Locacoes",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLocacao",
                table: "Locacoes",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRetorno",
                table: "Locacoes",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEsperada",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "DataLocacao",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "DataRetorno",
                table: "Locacoes");
        }
    }
}
