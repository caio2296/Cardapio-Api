using Microsoft.EntityFrameworkCore.Migrations;

namespace Cardapio.Persistence.Migrations
{
    public partial class PedidoM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Pedido_ProdutoId",
                table: "PedidoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Produto_ProdutoId1",
                table: "PedidoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoItem",
                table: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_PedidoItem_ProdutoId1",
                table: "PedidoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "PedidoItem");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "produto");

            migrationBuilder.RenameTable(
                name: "PedidoItem",
                newName: "pedidoItem");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "pedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "pedidoItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProdutoNome",
                table: "pedidoItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorProduto",
                table: "pedidoItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IdPedidoItem",
                table: "pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto",
                table: "produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidoItem",
                table: "pedidoItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedido",
                table: "pedido",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItem_PedidoId",
                table: "pedidoItem",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidoItem_ProdutoId",
                table: "pedidoItem",
                column: "ProdutoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidoItem_pedido_PedidoId",
                table: "pedidoItem",
                column: "PedidoId",
                principalTable: "pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidoItem_produto_ProdutoId",
                table: "pedidoItem",
                column: "ProdutoId",
                principalTable: "produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidoItem_pedido_PedidoId",
                table: "pedidoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidoItem_produto_ProdutoId",
                table: "pedidoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto",
                table: "produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidoItem",
                table: "pedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_pedidoItem_PedidoId",
                table: "pedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_pedidoItem_ProdutoId",
                table: "pedidoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedido",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "ProdutoNome",
                table: "pedidoItem");

            migrationBuilder.DropColumn(
                name: "ValorProduto",
                table: "pedidoItem");

            migrationBuilder.DropColumn(
                name: "IdPedidoItem",
                table: "pedido");

            migrationBuilder.RenameTable(
                name: "produto",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "pedidoItem",
                newName: "PedidoItem");

            migrationBuilder.RenameTable(
                name: "pedido",
                newName: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "PedidoItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "PedidoItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoItem",
                table: "PedidoItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoId1",
                table: "PedidoItem",
                column: "ProdutoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Pedido_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Produto_ProdutoId1",
                table: "PedidoItem",
                column: "ProdutoId1",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
