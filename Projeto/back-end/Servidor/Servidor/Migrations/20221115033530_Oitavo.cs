using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servidor.Migrations
{
    public partial class Oitavo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionamentos_Respostas_RespostaId",
                table: "Questionamentos");

            migrationBuilder.AlterColumn<int>(
                name: "RespostaId",
                table: "Questionamentos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionamentos_Respostas_RespostaId",
                table: "Questionamentos",
                column: "RespostaId",
                principalTable: "Respostas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionamentos_Respostas_RespostaId",
                table: "Questionamentos");

            migrationBuilder.AlterColumn<int>(
                name: "RespostaId",
                table: "Questionamentos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionamentos_Respostas_RespostaId",
                table: "Questionamentos",
                column: "RespostaId",
                principalTable: "Respostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
