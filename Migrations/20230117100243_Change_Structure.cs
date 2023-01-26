using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Miejsca_Zajete");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(name: "Id_Klienta", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.IdKlienta);
                });

            migrationBuilder.CreateTable(
                name: "Miejsca_Zajete",
                columns: table => new
                {
                    IdZajecia = table.Column<int>(name: "Id_Zajecia", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerMiejsca = table.Column<int>(name: "Numer_Miejsca", type: "int", nullable: false),
                    NumerSali = table.Column<int>(name: "Numer_Sali", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miejsca_Zajete", x => x.IdZajecia);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    Idrezerwacji = table.Column<int>(name: "Id_rezerwacji", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlientIdKlienta = table.Column<int>(name: "KlientId_Klienta", type: "int", nullable: true),
                    MiejsceIdZajecia = table.Column<int>(name: "MiejsceId_Zajecia", type: "int", nullable: true),
                    SeansIdseansu = table.Column<int>(name: "SeansId_seansu", type: "int", nullable: true),
                    DataRezerwacji = table.Column<DateTime>(name: "Data_Rezerwacji", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.Idrezerwacji);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Klienci_KlientId_Klienta",
                        column: x => x.KlientIdKlienta,
                        principalTable: "Klienci",
                        principalColumn: "Id_Klienta");
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Miejsca_Zajete_MiejsceId_Zajecia",
                        column: x => x.MiejsceIdZajecia,
                        principalTable: "Miejsca_Zajete",
                        principalColumn: "Id_Zajecia");
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Seanse_SeansId_seansu",
                        column: x => x.SeansIdseansu,
                        principalTable: "Seanse",
                        principalColumn: "Id_seansu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_KlientId_Klienta",
                table: "Rezerwacje",
                column: "KlientId_Klienta");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_MiejsceId_Zajecia",
                table: "Rezerwacje",
                column: "MiejsceId_Zajecia");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_SeansId_seansu",
                table: "Rezerwacje",
                column: "SeansId_seansu");
        }
    }
}
