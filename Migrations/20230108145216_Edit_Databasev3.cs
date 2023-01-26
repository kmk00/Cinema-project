using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class EditDatabasev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Miejsca_SalaId_Sali",
                table: "Seanse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Miejsca",
                table: "Miejsca");

            migrationBuilder.RenameTable(
                name: "Miejsca",
                newName: "Sale");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "Id_Sali");

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Sale_SalaId_Sali",
                table: "Seanse",
                column: "SalaId_Sali",
                principalTable: "Sale",
                principalColumn: "Id_Sali");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Sale_SalaId_Sali",
                table: "Seanse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Miejsca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miejsca",
                table: "Miejsca",
                column: "Id_Sali");

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Miejsca_SalaId_Sali",
                table: "Seanse",
                column: "SalaId_Sali",
                principalTable: "Miejsca",
                principalColumn: "Id_Sali");
        }
    }
}
