using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Produto
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });
            #endregion

            #region SolicitacaoCompra
            migrationBuilder.CreateTable(
                name: "SolicitacaoCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    CondicaoPagamento_Valor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoCompra", x => x.Id);
                });
            #endregion

            #region Item
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true),
                    Qtde = table.Column<int>(nullable: false),
                    SolicitacaoCompraId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                        column: x => x.SolicitacaoCompraId,
                        principalTable: "SolicitacaoCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            #endregion

            #region NomeFornecedor
            migrationBuilder.CreateTable(
                name: "NomeFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeFornecedor", x => x.Id);
                });
            #endregion

            #region UsuarioSolicitante
            migrationBuilder.CreateTable(
               name: "UsuarioSolicitante",
               columns: table => new
               {
                   Id = table.Column<Guid>(nullable: false),
                   Nome = table.Column<string>(nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_UsuarioSolicitante", x => x.Id);
               });
            #endregion

            //#region Money
            //migrationBuilder.CreateTable(
            //   name: "Money",
            //   columns: table => new
            //   {
            //       Id = table.Column<Guid>(nullable: false),
            //       Value = table.Column<decimal>(nullable: false),
            //       ProdutoId = table.Column<Guid>(nullable: false),
            //   },
            //   constraints: table =>
            //   {
            //       table.PrimaryKey("PK_Money", x => x.Id);
            //       table.ForeignKey(
            //            name: "FK_Money_Produto_ProdutoId",
            //            column: x => x.ProdutoId,
            //            principalTable: "Produto",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //   });
            //#endregion

            #region Indexs
            migrationBuilder.CreateIndex(
                name: "IX_Item_ProdutoId",
                table: "Item",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId");
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "SolicitacaoCompra");
        }
    }
}
