using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAvaliacaoKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_avaliacao",
                table: "avaliacao");

            migrationBuilder.AlterColumn<int>(
                name: "id_pedido",
                table: "avaliacao",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "avaliacao",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_avaliacao",
                table: "avaliacao",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_id_pedido",
                table: "avaliacao",
                column: "id_pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_avaliacao_pedidos_id_pedido",
                table: "avaliacao",
                column: "id_pedido",
                principalTable: "pedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_avaliacao_pedidos_id_pedido",
                table: "avaliacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_avaliacao",
                table: "avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_avaliacao_id_pedido",
                table: "avaliacao");

            migrationBuilder.AlterColumn<int>(
                name: "id_pedido",
                table: "avaliacao",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "avaliacao",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_avaliacao",
                table: "avaliacao",
                columns: new[] { "id", "id_pedido" });
        }
    }
}
