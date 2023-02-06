using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AddSolicitacaoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Produto_ProdutoId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Item_SolicitacaoCompraId",
                table: "Items",
                newName: "IX_Items_SolicitacaoCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ProdutoId",
                table: "Items",
                newName: "IX_Items_ProdutoId");

            migrationBuilder.AddColumn<int>(
                name: "NomeFornecedorId",
                table: "SolicitacaoCompra",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "condicaoPagamentos",
                columns: table => new
                {
                    Valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "nomeFornecedors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nomeFornecedors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarioSolicitantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioSolicitantes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Produto_ProdutoId",
                table: "Items",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Items",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_nomeFornecedors_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId",
                principalTable: "nomeFornecedors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_usuarioSolicitantes_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId",
                principalTable: "usuarioSolicitantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Produto_ProdutoId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_nomeFornecedors_NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_usuarioSolicitantes_UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "condicaoPagamentos");

            migrationBuilder.DropTable(
                name: "nomeFornecedors");

            migrationBuilder.DropTable(
                name: "usuarioSolicitantes");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Items_SolicitacaoCompraId",
                table: "Item",
                newName: "IX_Item_SolicitacaoCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ProdutoId",
                table: "Item",
                newName: "IX_Item_ProdutoId");

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Produto_ProdutoId",
                table: "Item",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
