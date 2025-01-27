using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotusStyle.API.Migrations
{
    /// <inheritdoc />
    public partial class InicioMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodProduto = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LinhaProduto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NacionalImportado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoVendido",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVendido", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_ProdutoVendido_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoVendido");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
