using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacaoIV.Venda.Api.Migrations
{
    /// <inheritdoc />
    public partial class Migration_1_0_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    NM_CLIENTE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NR_CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    DS_ENDERECO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    NR_TELEFONE = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    IN_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    NR_EAN = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    DS_PRODUTO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    VL_PRECO_COMPRA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VL_PRECO_VENDA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QT_ESTOQUE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IN_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VENDEDOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    NN_VENDEDOR = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DS_EMAIL = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    IN_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDEDOR", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TRANSACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    ID_CLIENTE = table.Column<Guid>(type: "char(36)", nullable: false),
                    ID_VENDEDOR = table.Column<Guid>(type: "char(36)", nullable: false),
                    IN_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_CLIENTE_ID_CLIENTE",
                        column: x => x.ID_CLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_VENDEDOR_ID_VENDEDOR",
                        column: x => x.ID_VENDEDOR,
                        principalTable: "VENDEDOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TRANSACAO_ITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    ID_PRODUTO = table.Column<Guid>(type: "char(36)", nullable: false),
                    VL_ITEM = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    QT_ITEM = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ID_TRANSACAO = table.Column<Guid>(type: "char(36)", nullable: true),
                    IN_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACAO_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_ITEM_PRODUTO_ID_PRODUTO",
                        column: x => x.ID_PRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_ITEM_TRANSACAO_ID_TRANSACAO",
                        column: x => x.ID_TRANSACAO,
                        principalTable: "TRANSACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_ID_CLIENTE",
                table: "TRANSACAO",
                column: "ID_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_ID_VENDEDOR",
                table: "TRANSACAO",
                column: "ID_VENDEDOR");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_ITEM_ID_PRODUTO",
                table: "TRANSACAO_ITEM",
                column: "ID_PRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_ITEM_ID_TRANSACAO",
                table: "TRANSACAO_ITEM",
                column: "ID_TRANSACAO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRANSACAO_ITEM");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "TRANSACAO");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "VENDEDOR");
        }
    }
}
