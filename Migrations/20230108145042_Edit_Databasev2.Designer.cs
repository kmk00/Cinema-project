﻿// <auto-generated />
using System;
using Kino.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kino.Migrations
{
    [DbContext(typeof(KinoContext))]
    [Migration("20230108145042_Edit_Databasev2")]
    partial class EditDatabasev2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kino.Models.Filmy", b =>
                {
                    b.Property<int>("Id_filmu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_filmu"));

                    b.Property<int>("Czas_trwania")
                        .HasColumnType("int");

                    b.Property<int?>("GatunekId_gatunku")
                        .HasColumnType("int");

                    b.Property<int?>("RezyserId_rezysera")
                        .HasColumnType("int");

                    b.Property<int>("Rok")
                        .HasColumnType("int");

                    b.Property<string>("Tytul")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_filmu");

                    b.HasIndex("GatunekId_gatunku");

                    b.HasIndex("RezyserId_rezysera");

                    b.ToTable("Filmy", (string)null);
                });

            modelBuilder.Entity("Kino.Models.Gatunki", b =>
                {
                    b.Property<int>("Id_gatunku")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_gatunku"));

                    b.Property<string>("Gatunek")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_gatunku");

                    b.ToTable("Gatunki", (string)null);
                });

            modelBuilder.Entity("Kino.Models.Klienci", b =>
                {
                    b.Property<int>("Id_Klienta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Klienta"));

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Klienta");

                    b.ToTable("Klienci", (string)null);
                });

            modelBuilder.Entity("Kino.Models.Rezerwacje", b =>
                {
                    b.Property<int>("Id_rezerwacji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_rezerwacji"));

                    b.Property<DateTime>("Data_Rezerwacji")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KlientId_Klienta")
                        .HasColumnType("int");

                    b.Property<int?>("SeansId_seansu")
                        .HasColumnType("int");

                    b.HasKey("Id_rezerwacji");

                    b.HasIndex("KlientId_Klienta");

                    b.HasIndex("SeansId_seansu");

                    b.ToTable("Rezerwacje", (string)null);
                });

            modelBuilder.Entity("Kino.Models.Rezyserzy", b =>
                {
                    b.Property<int>("Id_rezysera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_rezysera"));

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_rezysera");

                    b.ToTable("Rezyserzy", (string)null);
                });

            modelBuilder.Entity("Kino.Models.Sale", b =>
                {
                    b.Property<int>("Id_Sali")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Sali"));

                    b.Property<bool>("CzyZajete")
                        .HasColumnType("bit");

                    b.Property<int>("Miejsce")
                        .HasColumnType("int");

                    b.HasKey("Id_Sali");

                    b.ToTable("Miejsca", (string)null);
                });

            modelBuilder.Entity("Kino.Models.Seanse", b =>
                {
                    b.Property<int>("Id_seansu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_seansu"));

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int?>("FilmId_filmu")
                        .HasColumnType("int");

                    b.Property<int?>("SalaId_Sali")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_seansu");

                    b.HasIndex("FilmId_filmu");

                    b.HasIndex("SalaId_Sali");

                    b.ToTable("Seanse", (string)null);
                });

            modelBuilder.Entity("Kino.Models.Filmy", b =>
                {
                    b.HasOne("Kino.Models.Gatunki", "Gatunek")
                        .WithMany("Film")
                        .HasForeignKey("GatunekId_gatunku");

                    b.HasOne("Kino.Models.Rezyserzy", "Rezyser")
                        .WithMany("Filmy")
                        .HasForeignKey("RezyserId_rezysera");

                    b.Navigation("Gatunek");

                    b.Navigation("Rezyser");
                });

            modelBuilder.Entity("Kino.Models.Rezerwacje", b =>
                {
                    b.HasOne("Kino.Models.Klienci", "Klient")
                        .WithMany("Rezerwacja")
                        .HasForeignKey("KlientId_Klienta");

                    b.HasOne("Kino.Models.Seanse", "Seans")
                        .WithMany("Rezerwacja")
                        .HasForeignKey("SeansId_seansu");

                    b.Navigation("Klient");

                    b.Navigation("Seans");
                });

            modelBuilder.Entity("Kino.Models.Seanse", b =>
                {
                    b.HasOne("Kino.Models.Filmy", "Film")
                        .WithMany("Seans")
                        .HasForeignKey("FilmId_filmu");

                    b.HasOne("Kino.Models.Sale", "Sala")
                        .WithMany("Seans")
                        .HasForeignKey("SalaId_Sali");

                    b.Navigation("Film");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Kino.Models.Filmy", b =>
                {
                    b.Navigation("Seans");
                });

            modelBuilder.Entity("Kino.Models.Gatunki", b =>
                {
                    b.Navigation("Film");
                });

            modelBuilder.Entity("Kino.Models.Klienci", b =>
                {
                    b.Navigation("Rezerwacja");
                });

            modelBuilder.Entity("Kino.Models.Rezyserzy", b =>
                {
                    b.Navigation("Filmy");
                });

            modelBuilder.Entity("Kino.Models.Sale", b =>
                {
                    b.Navigation("Seans");
                });

            modelBuilder.Entity("Kino.Models.Seanse", b =>
                {
                    b.Navigation("Rezerwacja");
                });
#pragma warning restore 612, 618
        }
    }
}