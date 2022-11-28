using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servidor.Migrations
{
    public partial class Quarto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Venda_VendaId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_VendaId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataExpiracao",
                table: "Venda",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoId",
                table: "Venda",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_AvaliacaoId",
                table: "Venda",
                column: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Avaliacoes_AvaliacaoId",
                table: "Venda",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Avaliacoes_AvaliacaoId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_AvaliacaoId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "AvaliacaoId",
                table: "Venda");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataExpiracao",
                table: "Venda",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "VendaId",
                table: "Avaliacoes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_VendaId",
                table: "Avaliacoes",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Venda_VendaId",
                table: "Avaliacoes",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id");
        }
    }
}
