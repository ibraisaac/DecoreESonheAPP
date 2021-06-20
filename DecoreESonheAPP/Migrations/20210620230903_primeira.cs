using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DecoreESonheAPP.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Identificador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", maxLength: 60, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "TipoProdutos",
                columns: table => new
                {
                    Identificador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProdutos", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Identificador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    DataEntrega = table.Column<DateTime>(type: "Date", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "Date", nullable: false),
                    TipoPagamento = table.Column<string>(nullable: false),
                    TipoEntrega = table.Column<string>(nullable: false),
                    CanalVenda = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    ClienteIdentificador = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(type: "Varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteIdentificador",
                        column: x => x.ClienteIdentificador,
                        principalTable: "Clientes",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Identificador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    IdTipoProduto = table.Column<int>(type: "int", nullable: false),
                    TipoProdutoIdentificador = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Produtos_TipoProdutos_TipoProdutoIdentificador",
                        column: x => x.TipoProdutoIdentificador,
                        principalTable: "TipoProdutos",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItens",
                columns: table => new
                {
                    Identificador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    ProdutoIdentificador = table.Column<int>(nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    PedidoIdentificador = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItens", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Pedidos_PedidoIdentificador",
                        column: x => x.PedidoIdentificador,
                        principalTable: "Pedidos",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Produtos_ProdutoIdentificador",
                        column: x => x.ProdutoIdentificador,
                        principalTable: "Produtos",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_PedidoIdentificador",
                table: "PedidoItens",
                column: "PedidoIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_ProdutoIdentificador",
                table: "PedidoItens",
                column: "ProdutoIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteIdentificador",
                table: "Pedidos",
                column: "ClienteIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TipoProdutoIdentificador",
                table: "Produtos",
                column: "TipoProdutoIdentificador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItens");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoProdutos");
        }
    }
}
