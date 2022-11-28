using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servidor.Migrations
{
    public partial class Sexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Avaliacoes_AvaliacaoId",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "AvaliacaoId",
                table: "Vendas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Avaliacoes_AvaliacaoId",
                table: "Vendas",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Avaliacoes_AvaliacaoId",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "AvaliacaoId",
                table: "Vendas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Avaliacoes_AvaliacaoId",
                table: "Vendas",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
