using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servidor.Migrations
{
    public partial class Quinto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionamentos_Venda_VendaId",
                table: "Questionamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Avaliacoes_AvaliacaoId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Categorias_CategoriaId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_StatusVendas_StatusVendaId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Usuarios_UsuarioId",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venda",
                table: "Venda");

            migrationBuilder.RenameTable(
                name: "Venda",
                newName: "Vendas");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_UsuarioId",
                table: "Vendas",
                newName: "IX_Vendas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_StatusVendaId",
                table: "Vendas",
                newName: "IX_Vendas_StatusVendaId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_CategoriaId",
                table: "Vendas",
                newName: "IX_Vendas_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_AvaliacaoId",
                table: "Vendas",
                newName: "IX_Vendas_AvaliacaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendas",
                table: "Vendas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionamentos_Vendas_VendaId",
                table: "Questionamentos",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Avaliacoes_AvaliacaoId",
                table: "Vendas",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Categorias_CategoriaId",
                table: "Vendas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_StatusVendas_StatusVendaId",
                table: "Vendas",
                column: "StatusVendaId",
                principalTable: "StatusVendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Usuarios_UsuarioId",
                table: "Vendas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionamentos_Vendas_VendaId",
                table: "Questionamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Avaliacoes_AvaliacaoId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Categorias_CategoriaId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_StatusVendas_StatusVendaId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Usuarios_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendas",
                table: "Vendas");

            migrationBuilder.RenameTable(
                name: "Vendas",
                newName: "Venda");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Venda",
                newName: "IX_Venda_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_StatusVendaId",
                table: "Venda",
                newName: "IX_Venda_StatusVendaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_CategoriaId",
                table: "Venda",
                newName: "IX_Venda_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_AvaliacaoId",
                table: "Venda",
                newName: "IX_Venda_AvaliacaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venda",
                table: "Venda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionamentos_Venda_VendaId",
                table: "Questionamentos",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Avaliacoes_AvaliacaoId",
                table: "Venda",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Categorias_CategoriaId",
                table: "Venda",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_StatusVendas_StatusVendaId",
                table: "Venda",
                column: "StatusVendaId",
                principalTable: "StatusVendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Usuarios_UsuarioId",
                table: "Venda",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
