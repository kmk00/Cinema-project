using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class AddKina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmy_Eventy_EventId_eventu",
                table: "Filmy");

            migrationBuilder.DropTable(
                name: "Eventy");

            migrationBuilder.DropIndex(
                name: "IX_Filmy_EventId_eventu",
                table: "Filmy");

            migrationBuilder.DropColumn(
                name: "EventId_eventu",
                table: "Filmy");

            migrationBuilder.AddColumn<int>(
                name: "kinoId_kina",
                table: "Seanse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kina",
                columns: table => new
                {
                    Idkina = table.Column<int>(name: "Id_kina", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKina = table.Column<string>(name: "Nazwa_Kina", type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kina", x => x.Idkina);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seanse_kinoId_kina",
                table: "Seanse",
                column: "kinoId_kina");

            migrationBuilder.AddForeignKey(
                name: "FK_Seanse_Kina_kinoId_kina",
                table: "Seanse",
                column: "kinoId_kina",
                principalTable: "Kina",
                principalColumn: "Id_kina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seanse_Kina_kinoId_kina",
                table: "Seanse");

            migrationBuilder.DropTable(
                name: "Kina");

            migrationBuilder.DropIndex(
                name: "IX_Seanse_kinoId_kina",
                table: "Seanse");

            migrationBuilder.DropColumn(
                name: "kinoId_kina",
                table: "Seanse");

            migrationBuilder.AddColumn<int>(
                name: "EventId_eventu",
                table: "Filmy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Eventy",
                columns: table => new
                {
                    Ideventu = table.Column<int>(name: "Id_eventu", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaEventu = table.Column<string>(name: "Nazwa_Eventu", type: "nvarchar(max)", nullable: true),
                    StartEventu = table.Column<DateTime>(name: "Start_Eventu", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventy", x => x.Ideventu);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_EventId_eventu",
                table: "Filmy",
                column: "EventId_eventu");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmy_Eventy_EventId_eventu",
                table: "Filmy",
                column: "EventId_eventu",
                principalTable: "Eventy",
                principalColumn: "Id_eventu");
        }
    }
}
