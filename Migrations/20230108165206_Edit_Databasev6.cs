using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class EditDatabasev6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Sale_SalaId_Sali",
                table: "Seanse");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Seanse_SalaId_Sali",
                table: "Seanse");

            migrationBuilder.DropColumn(
                name: "SalaId_Sali",
                table: "Seanse");

            migrationBuilder.AddColumn<int>(
                name: "Miejsce",
                table: "Rezerwacje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miejsce",
                table: "Rezerwacje");

            migrationBuilder.AddColumn<int>(
                name: "SalaId_Sali",
                table: "Seanse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSali = table.Column<int>(name: "Id_Sali", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejsce = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSali);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seanse_SalaId_Sali",
                table: "Seanse",
                column: "SalaId_Sali");

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Sale_SalaId_Sali",
                table: "Seanse",
                column: "SalaId_Sali",
                principalTable: "Sale",
                principalColumn: "Id_Sali");
        }
    }
}
