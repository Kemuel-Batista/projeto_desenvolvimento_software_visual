using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Banco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoriaservico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaservico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "prestadores",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Biografia = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestadores", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "avaliacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_pedido = table.Column<int>(type: "integer", nullable: false),
                    cpf_cliente = table.Column<string>(type: "text", nullable: true),
                    cpf_prestador = table.Column<string>(type: "text", nullable: true),
                    avaliacao_prestador = table.Column<string>(type: "text", nullable: true),
                    avaliacao_cliente = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_avaliacao_clientes_cpf_cliente",
                        column: x => x.cpf_cliente,
                        principalTable: "clientes",
                        principalColumn: "Cpf");
                    table.ForeignKey(
                        name: "FK_avaliacao_prestadores_cpf_prestador",
                        column: x => x.cpf_prestador,
                        principalTable: "prestadores",
                        principalColumn: "Cpf");
                });

            migrationBuilder.CreateTable(
                name: "servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    id_categoria_servico = table.Column<int>(type: "integer", nullable: false),
                    cpf_prestador = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servicos_categoriaservico_id_categoria_servico",
                        column: x => x.id_categoria_servico,
                        principalTable: "categoriaservico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicos_prestadores_cpf_prestador",
                        column: x => x.cpf_prestador,
                        principalTable: "prestadores",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_servico = table.Column<int>(type: "integer", nullable: false),
                    cpf_cliente = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedidos_clientes_cpf_cliente",
                        column: x => x.cpf_cliente,
                        principalTable: "clientes",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidos_servicos_id_servico",
                        column: x => x.id_servico,
                        principalTable: "servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_cpf_cliente",
                table: "avaliacao",
                column: "cpf_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_cpf_prestador",
                table: "avaliacao",
                column: "cpf_prestador");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_cpf_cliente",
                table: "pedidos",
                column: "cpf_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_servico",
                table: "pedidos",
                column: "id_servico");

            migrationBuilder.CreateIndex(
                name: "IX_servicos_cpf_prestador",
                table: "servicos",
                column: "cpf_prestador");

            migrationBuilder.CreateIndex(
                name: "IX_servicos_id_categoria_servico",
                table: "servicos",
                column: "id_categoria_servico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacao");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "servicos");

            migrationBuilder.DropTable(
                name: "categoriaservico");

            migrationBuilder.DropTable(
                name: "prestadores");
        }
    }
}
