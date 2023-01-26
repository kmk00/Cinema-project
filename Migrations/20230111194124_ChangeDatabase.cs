using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miejsce",
                table: "Rezerwacje");

            migrationBuilder.AddColumn<int>(
                name: "MiejsceId_Zajecia",
                table: "Rezerwacje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plakat",
                table: "Filmy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Miejsca_Zajete",
                columns: table => new
                {
                    IdZajecia = table.Column<int>(name: "Id_Zajecia", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerSali = table.Column<int>(name: "Numer_Sali", type: "int", nullable: false),
                    NumerMiejsca = table.Column<int>(name: "Numer_Miejsca", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miejsca_Zajete", x => x.IdZajecia);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_MiejsceId_Zajecia",
                table: "Rezerwacje",
                column: "MiejsceId_Zajecia");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Miejsca_Zajete_MiejsceId_Zajecia",
                table: "Rezerwacje",
                column: "MiejsceId_Zajecia",
                principalTable: "Miejsca_Zajete",
                principalColumn: "Id_Zajecia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Miejsca_Zajete_MiejsceId_Zajecia",
                table: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Miejsca_Zajete");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_MiejsceId_Zajecia",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "MiejsceId_Zajecia",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "Plakat",
                table: "Filmy");

            migrationBuilder.AddColumn<int>(
                name: "Miejsce",
                table: "Rezerwacje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
