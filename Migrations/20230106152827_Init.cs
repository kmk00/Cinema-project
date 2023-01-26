using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gatunki",
                columns: table => new
                {
                    Idgatunku = table.Column<int>(name: "Id_gatunku", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gatunek = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunki", x => x.Idgatunku);
                });

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
                name: "Miejsca",
                columns: table => new
                {
                    IdSali = table.Column<int>(name: "Id_Sali", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejsce = table.Column<int>(type: "int", nullable: false),
                    CzyZajete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miejsca", x => x.IdSali);
                });

            migrationBuilder.CreateTable(
                name: "Rezyserzy",
                columns: table => new
                {
                    Idrezysera = table.Column<int>(name: "Id_rezysera", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezyserzy", x => x.Idrezysera);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSali = table.Column<int>(name: "Id_Sali", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejsca = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    Idfilmu = table.Column<int>(name: "Id_filmu", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Czastrwania = table.Column<int>(name: "Czas_trwania", type: "int", nullable: false),
                    Rok = table.Column<int>(type: "int", nullable: false),
                    GatunekIdgatunku = table.Column<int>(name: "GatunekId_gatunku", type: "int", nullable: true),
                    RezyserIdrezysera = table.Column<int>(name: "RezyserId_rezysera", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.Idfilmu);
                    table.ForeignKey(
                        name: "FK_Filmy_Gatunki_GatunekId_gatunku",
                        column: x => x.GatunekIdgatunku,
                        principalTable: "Gatunki",
                        principalColumn: "Id_gatunku");
                    table.ForeignKey(
                        name: "FK_Filmy_Rezyserzy_RezyserId_rezysera",
                        column: x => x.RezyserIdrezysera,
                        principalTable: "Rezyserzy",
                        principalColumn: "Id_rezysera");
                });

            migrationBuilder.CreateTable(
                name: "Seanse",
                columns: table => new
                {
                    Idseansu = table.Column<int>(name: "Id_seansu", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    FilmIdfilmu = table.Column<int>(name: "FilmId_filmu", type: "int", nullable: true),
                    SalaIdSali = table.Column<int>(name: "SalaId_Sali", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seanse", x => x.Idseansu);
                    table.ForeignKey(
                        name: "FK_Seanse_Filmy_FilmId_filmu",
                        column: x => x.FilmIdfilmu,
                        principalTable: "Filmy",
                        principalColumn: "Id_filmu");
                    table.ForeignKey(
                        name: "FK_Seanse_Sale_SalaId_Sali",
                        column: x => x.SalaIdSali,
                        principalTable: "Sale",
                        principalColumn: "Id_Sali");
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    Idrezerwacji = table.Column<int>(name: "Id_rezerwacji", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRezerwacji = table.Column<DateTime>(name: "Data_Rezerwacji", type: "datetime2", nullable: false),
                    SeansIdseansu = table.Column<int>(name: "SeansId_seansu", type: "int", nullable: true),
                    KlientIdKlienta = table.Column<int>(name: "KlientId_Klienta", type: "int", nullable: true)
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
                        name: "FK_Rezerwacje_Seanse_SeansId_seansu",
                        column: x => x.SeansIdseansu,
                        principalTable: "Seanse",
                        principalColumn: "Id_seansu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_GatunekId_gatunku",
                table: "Filmy",
                column: "GatunekId_gatunku");

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_RezyserId_rezysera",
                table: "Filmy",
                column: "RezyserId_rezysera");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_KlientId_Klienta",
                table: "Rezerwacje",
                column: "KlientId_Klienta");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_SeansId_seansu",
                table: "Rezerwacje",
                column: "SeansId_seansu");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_MiejscaId_Sali",
                table: "Sale",
                column: "MiejscaId_Sali");

            migrationBuilder.CreateIndex(
                name: "IX_Seanse_FilmId_filmu",
                table: "Seanse",
                column: "FilmId_filmu");

            migrationBuilder.CreateIndex(
                name: "IX_Seanse_SalaId_Sali",
                table: "Seanse",
                column: "SalaId_Sali");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Seanse");

            migrationBuilder.DropTable(
                name: "Filmy");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Gatunki");

            migrationBuilder.DropTable(
                name: "Rezyserzy");

            migrationBuilder.DropTable(
                name: "Miejsca");
        }
    }
}
