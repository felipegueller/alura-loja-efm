using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraLoja.Migrations
{
    /// <inheritdoc />
    public partial class addingcolumnunidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produto",
                newName: "PrecoUnitario");

            migrationBuilder.AddColumn<string>(
                name: "Unidade",
                table: "Produto",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidade",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "Produto",
                newName: "Preco");
        }
    }
}
