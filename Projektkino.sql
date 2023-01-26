USE [master]
GO
/****** Object:  Database [kino]    Script Date: 17.01.2023 17:18:13 ******/
CREATE DATABASE [kino]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kino', FILENAME = N'F:\Nowy folder\MSSQL15.SQLEXPRESS\MSSQL\DATA\kino.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kino_log', FILENAME = N'F:\Nowy folder\MSSQL15.SQLEXPRESS\MSSQL\DATA\kino_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [kino] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kino].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kino] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kino] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kino] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kino] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kino] SET ARITHABORT OFF 
GO
ALTER DATABASE [kino] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kino] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kino] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kino] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kino] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kino] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kino] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kino] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kino] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kino] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kino] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kino] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kino] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kino] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kino] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kino] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kino] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kino] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [kino] SET  MULTI_USER 
GO
ALTER DATABASE [kino] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kino] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kino] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kino] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kino] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [kino] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [kino] SET QUERY_STORE = OFF
GO
USE [kino]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17.01.2023 17:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filmy]    Script Date: 17.01.2023 17:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filmy](
	[Id_filmu] [int] IDENTITY(1,1) NOT NULL,
	[Tytul] [nvarchar](max) NULL,
	[Czas_trwania] [int] NOT NULL,
	[Rok] [int] NOT NULL,
	[GatunekId_gatunku] [int] NULL,
	[RezyserId_rezysera] [int] NULL,
	[Plakat] [nvarchar](max) NULL,
 CONSTRAINT [PK_Filmy] PRIMARY KEY CLUSTERED 
(
	[Id_filmu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gatunki]    Script Date: 17.01.2023 17:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gatunki](
	[Id_gatunku] [int] IDENTITY(1,1) NOT NULL,
	[Gatunek] [nvarchar](max) NULL,
 CONSTRAINT [PK_Gatunki] PRIMARY KEY CLUSTERED 
(
	[Id_gatunku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kina]    Script Date: 17.01.2023 17:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kina](
	[Id_kina] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa_Kina] [nvarchar](max) NULL,
	[Adres] [nvarchar](max) NULL,
 CONSTRAINT [PK_Kina] PRIMARY KEY CLUSTERED 
(
	[Id_kina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rezyserzy]    Script Date: 17.01.2023 17:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezyserzy](
	[Id_rezysera] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [nvarchar](max) NULL,
	[Nazwisko] [nvarchar](max) NULL,
 CONSTRAINT [PK_Rezyserzy] PRIMARY KEY CLUSTERED 
(
	[Id_rezysera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seanse]    Script Date: 17.01.2023 17:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seanse](
	[Id_seansu] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime2](7) NOT NULL,
	[Cena] [int] NOT NULL,
	[FilmId_filmu] [int] NULL,
	[kinoId_kina] [int] NULL,
 CONSTRAINT [PK_Seanse] PRIMARY KEY CLUSTERED 
(
	[Id_seansu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230106152827_Init', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230106153044_Create_Database', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230108143925_Edit_Database', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230108145042_Edit_Databasev2', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230108145216_Edit_Databasev3', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230108163107_Edit_Databasev4', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230108163429_Edit_Databasev5', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230108165206_Edit_Databasev6', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230110212603_asddsa', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230111194124_ChangeDatabase', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230117100243_Change_Structure', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230117125230_AddKina', N'7.0.1')
GO
SET IDENTITY_INSERT [dbo].[Filmy] ON 

INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (1, N'One Flew Over the Cuckoo''s Nest', 133, 1975, 1, 1, N'oneflewoverthecuckoosnest.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (2, N'Pulp fiction', 154, 1994, 2, 2, N'pulpfiction.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (3, N'Fight club', 139, 1999, 6, 3, N'fightclub.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (4, N'Django Unchained', 165, 2012, 4, 2, N'djangounchained.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (5, N'Gran torrino', 116, 2008, 1, 4, N'grantorrino.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (8, N'Leon', 110, 1994, 1, 5, N'leon.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (9, N'Whiplash', 105, 2014, 5, 6, N'whiplash.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (10, N'Amadeus', 160, 1984, 5, 1, N'amadeus.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (11, N'Psycho', 109, 1960, 6, 7, N'psycho.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (12, N'Contratiempo', 104, 2016, 7, 8, N'contratiempo.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (14, N'Black Swan', 104, 2010, 1, 9, N'blackswan.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (15, N'The Texas Chain Saw Massacre', 83, 1974, 8, 11, N'thetexaschainsawmassacre.png')
INSERT [dbo].[Filmy] ([Id_filmu], [Tytul], [Czas_trwania], [Rok], [GatunekId_gatunku], [RezyserId_rezysera], [Plakat]) VALUES (16, N'Get Out', 83, 2017, 8, 10, N'getout.png')
SET IDENTITY_INSERT [dbo].[Filmy] OFF
GO
SET IDENTITY_INSERT [dbo].[Gatunki] ON 

INSERT [dbo].[Gatunki] ([Id_gatunku], [Gatunek]) VALUES (1, N'Dramat')
INSERT [dbo].[Gatunki] ([Id_gatunku], [Gatunek]) VALUES (2, N'Gangsterski')
INSERT [dbo].[Gatunki] ([Id_gatunku], [Gatunek]) VALUES (3, N'Psychologiczny')
INSERT [dbo].[Gatunki] ([Id_gatunku], [Gatunek]) VALUES (4, N'Western')
INSERT [dbo].[Gatunki] ([Id_gatunku], [Gatunek]) VALUES (5, N'Muzyczny')
INSERT [dbo].[Gatunki] ([Id_gatunku], [Gatunek]) VALUES (6, N'Thriller')
INSERT [dbo].[Gatunki] ([Id_gatunku], [Gatunek]) VALUES (7, N'Kryminał')
INSERT [dbo].[Gatunki] ([Id_gatunku], [Gatunek]) VALUES (8, N'Horror')
SET IDENTITY_INSERT [dbo].[Gatunki] OFF
GO
SET IDENTITY_INSERT [dbo].[Kina] ON 

INSERT [dbo].[Kina] ([Id_kina], [Nazwa_Kina], [Adres]) VALUES (1, N'Ból oczu', N'Nawojowa 123')
INSERT [dbo].[Kina] ([Id_kina], [Nazwa_Kina], [Adres]) VALUES (2, N'Wita widza', N'Krakowska 11')
INSERT [dbo].[Kina] ([Id_kina], [Nazwa_Kina], [Adres]) VALUES (3, N'Same filmy', N'Januszeksa 17')
SET IDENTITY_INSERT [dbo].[Kina] OFF
GO
SET IDENTITY_INSERT [dbo].[Rezyserzy] ON 

INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (1, N'Milos', N'Forman')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (2, N'Quentin', N'Tarantino')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (3, N'
David', N'Fincher')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (4, N'Clint', N'Eastwood')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (5, N'Luc', N'Besson')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (6, N'Damien', N'Chazelle')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (7, N'Alfred', N'Hitchcock')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (8, N'Oriol', N'Paulo')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (9, N'Darren', N'Aronofsky')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (10, N'
Jordan', N'Peele')
INSERT [dbo].[Rezyserzy] ([Id_rezysera], [Imie], [Nazwisko]) VALUES (11, N'Tobe', N'Hooper')
SET IDENTITY_INSERT [dbo].[Rezyserzy] OFF
GO
SET IDENTITY_INSERT [dbo].[Seanse] ON 

INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (2, CAST(N'2023-01-04T17:00:00.0000000' AS DateTime2), 21, 8, 1)
INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (3, CAST(N'2023-01-04T14:00:00.0000000' AS DateTime2), 17, 3, 1)
INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (7, CAST(N'2023-01-04T11:00:00.0000000' AS DateTime2), 19, 5, 2)
INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (14, CAST(N'2023-01-03T22:00:00.0000000' AS DateTime2), 21, 9, 2)
INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (15, CAST(N'2023-01-03T17:00:00.0000000' AS DateTime2), 17, 10, 2)
INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (16, CAST(N'2023-01-03T14:00:00.0000000' AS DateTime2), 19, 11, 3)
INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (20, CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), 12, 11, 3)
INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (21, CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), 28, 3, 2)
INSERT [dbo].[Seanse] ([Id_seansu], [Start], [Cena], [FilmId_filmu], [kinoId_kina]) VALUES (22, CAST(N'2023-01-26T18:10:00.0000000' AS DateTime2), 324, 8, 2)
SET IDENTITY_INSERT [dbo].[Seanse] OFF
GO
/****** Object:  Index [IX_Filmy_GatunekId_gatunku]    Script Date: 17.01.2023 17:18:13 ******/
CREATE NONCLUSTERED INDEX [IX_Filmy_GatunekId_gatunku] ON [dbo].[Filmy]
(
	[GatunekId_gatunku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Filmy_RezyserId_rezysera]    Script Date: 17.01.2023 17:18:13 ******/
CREATE NONCLUSTERED INDEX [IX_Filmy_RezyserId_rezysera] ON [dbo].[Filmy]
(
	[RezyserId_rezysera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seanse_FilmId_filmu]    Script Date: 17.01.2023 17:18:13 ******/
CREATE NONCLUSTERED INDEX [IX_Seanse_FilmId_filmu] ON [dbo].[Seanse]
(
	[FilmId_filmu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seanse_kinoId_kina]    Script Date: 17.01.2023 17:18:13 ******/
CREATE NONCLUSTERED INDEX [IX_Seanse_kinoId_kina] ON [dbo].[Seanse]
(
	[kinoId_kina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Filmy]  WITH CHECK ADD  CONSTRAINT [FK_Filmy_Gatunki_GatunekId_gatunku] FOREIGN KEY([GatunekId_gatunku])
REFERENCES [dbo].[Gatunki] ([Id_gatunku])
GO
ALTER TABLE [dbo].[Filmy] CHECK CONSTRAINT [FK_Filmy_Gatunki_GatunekId_gatunku]
GO
ALTER TABLE [dbo].[Filmy]  WITH CHECK ADD  CONSTRAINT [FK_Filmy_Rezyserzy_RezyserId_rezysera] FOREIGN KEY([RezyserId_rezysera])
REFERENCES [dbo].[Rezyserzy] ([Id_rezysera])
GO
ALTER TABLE [dbo].[Filmy] CHECK CONSTRAINT [FK_Filmy_Rezyserzy_RezyserId_rezysera]
GO
ALTER TABLE [dbo].[Seanse]  WITH CHECK ADD  CONSTRAINT [FK_Seanse_Filmy_FilmId_filmu] FOREIGN KEY([FilmId_filmu])
REFERENCES [dbo].[Filmy] ([Id_filmu])
GO
ALTER TABLE [dbo].[Seanse] CHECK CONSTRAINT [FK_Seanse_Filmy_FilmId_filmu]
GO
ALTER TABLE [dbo].[Seanse]  WITH CHECK ADD  CONSTRAINT [FK_Seanse_Kina_kinoId_kina] FOREIGN KEY([kinoId_kina])
REFERENCES [dbo].[Kina] ([Id_kina])
GO
ALTER TABLE [dbo].[Seanse] CHECK CONSTRAINT [FK_Seanse_Kina_kinoId_kina]
GO
USE [master]
GO
ALTER DATABASE [kino] SET  READ_WRITE 
GO
