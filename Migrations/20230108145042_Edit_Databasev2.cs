using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class EditDatabasev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Sale_SalaId_Sali",
                table: "Seanse");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Miejsca_SalaId_Sali",
                table: "Seanse",
                column: "SalaId_Sali",
                principalTable: "Miejsca",
                principalColumn: "Id_Sali");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Miejsca_SalaId_Sali",
                table: "Seanse");

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSali = table.Column<int>(name: "Id_Sali", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiejscaIdSali = table.Column<int>(name: "MiejscaId_Sali", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSali);
                    table.ForeignKey(
                        name: "FK_Sale_Miejsca_MiejscaId_Sali",
                        column: x => x.MiejscaIdSali,
                        principalTable: "Miejsca",
                        principalColumn: "Id_Sali");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_MiejscaId_Sali",
                table: "Sale",
                column: "MiejscaId_Sali");

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Sale_SalaId_Sali",
                table: "Seanse",
                column: "SalaId_Sali",
                principalTable: "Sale",
                principalColumn: "Id_Sali");
        }
    }
}
