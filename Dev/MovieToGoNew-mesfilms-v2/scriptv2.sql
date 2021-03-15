USE [master]
GO
/****** Object:  Database [DBMovieToGo]    Script Date: 08.06.2020 22:02:01 ******/
CREATE DATABASE [DBMovieToGo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBMovieToGo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBMovieToGo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBMovieToGo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBMovieToGo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBMovieToGo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBMovieToGo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBMovieToGo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBMovieToGo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBMovieToGo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBMovieToGo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBMovieToGo] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBMovieToGo] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBMovieToGo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBMovieToGo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBMovieToGo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBMovieToGo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBMovieToGo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBMovieToGo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBMovieToGo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBMovieToGo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBMovieToGo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBMovieToGo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBMovieToGo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBMovieToGo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBMovieToGo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBMovieToGo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBMovieToGo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBMovieToGo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBMovieToGo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBMovieToGo] SET  MULTI_USER 
GO
ALTER DATABASE [DBMovieToGo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBMovieToGo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBMovieToGo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBMovieToGo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBMovieToGo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBMovieToGo] SET QUERY_STORE = OFF
GO
USE [DBMovieToGo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08.06.2020 22:02:01 ******/
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
/****** Object:  Table [dbo].[ACTEURS]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTEURS](
	[ID_ACTEUR] [smallint] IDENTITY(1,1) NOT NULL,
	[NOM] [char](32) NULL,
	[PRENOM] [char](32) NULL,
 CONSTRAINT [PK_ACTEURS] PRIMARY KEY CLUSTERED 
(
	[ID_ACTEUR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMMENTAIRE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMMENTAIRE](
	[ID_COMMENTAIRE] [smallint] IDENTITY(1,1) NOT NULL,
	[ID_USER] [nvarchar](450) NOT NULL,
	[ID_FILM] [smallint] NOT NULL,
	[COMMENTAIRE] [char](255) NOT NULL,
	[STATUT] [bit] NOT NULL,
 CONSTRAINT [PK_COMMENTAIRE] PRIMARY KEY CLUSTERED 
(
	[ID_COMMENTAIRE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DISTRIBUTEUR]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DISTRIBUTEUR](
	[ID_DISTRIBUTEUR] [smallint] IDENTITY(1,1) NOT NULL,
	[NOM] [char](32) NOT NULL,
 CONSTRAINT [PK_DISTRIBUTEUR] PRIMARY KEY CLUSTERED 
(
	[ID_DISTRIBUTEUR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAIT_PARTIE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAIT_PARTIE](
	[ID_GENRE] [smallint] NOT NULL,
	[ID_FILM] [smallint] NOT NULL,
 CONSTRAINT [PK_FAIT_PARTIE] PRIMARY KEY CLUSTERED 
(
	[ID_GENRE] ASC,
	[ID_FILM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FILM]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FILM](
	[ID_FILM] [smallint] IDENTITY(1,1) NOT NULL,
	[ID_DISTRIBUTEUR] [smallint] NOT NULL,
	[ID_SOUS_TITRE] [smallint] NOT NULL,
	[ID_LANGUE] [smallint] NOT NULL,
	[ID_NATIONALITE] [smallint] NOT NULL,
	[NOM] [char](32) NOT NULL,
	[DATE_DE_SORTIE] [datetime] NOT NULL,
	[DESCRIPTION] [text] NULL,
	[DUREE] [smallint] NOT NULL,
	[PRIX] [decimal](10, 2) NOT NULL,
	[FICHIER] [text] NULL,
 CONSTRAINT [PK_FILM] PRIMARY KEY CLUSTERED 
(
	[ID_FILM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FILM_POSSEDE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FILM_POSSEDE](
	[ID_FILM_POSSEDE] [smallint] IDENTITY(1,1) NOT NULL,
	[ID_FILM] [smallint] NOT NULL,
	[ID_USER] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_FILM_POSSEDE] PRIMARY KEY CLUSTERED 
(
	[ID_FILM_POSSEDE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GENRE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GENRE](
	[ID_GENRE] [smallint] IDENTITY(1,1) NOT NULL,
	[NOM] [char](32) NOT NULL,
 CONSTRAINT [PK_GENRE] PRIMARY KEY CLUSTERED 
(
	[ID_GENRE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOUE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOUE](
	[ID_ACTEUR] [smallint] NOT NULL,
	[ID_FILM] [smallint] NOT NULL,
 CONSTRAINT [PK_JOUE] PRIMARY KEY CLUSTERED 
(
	[ID_ACTEUR] ASC,
	[ID_FILM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LANGUE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LANGUE](
	[ID_LANGUE] [smallint] IDENTITY(1,1) NOT NULL,
	[NOM] [char](32) NOT NULL,
 CONSTRAINT [PK_LANGUE] PRIMARY KEY CLUSTERED 
(
	[ID_LANGUE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIST]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIST](
	[ID_LIST] [smallint] IDENTITY(1,1) NOT NULL,
	[ID_USER] [nvarchar](450) NOT NULL,
	[NOM] [char](32) NOT NULL,
 CONSTRAINT [PK_LIST] PRIMARY KEY CLUSTERED 
(
	[ID_LIST] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIST_F]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIST_F](
	[ID_LIST_F] [smallint] IDENTITY(1,1) NOT NULL,
	[ID_FILM] [smallint] NOT NULL,
	[ID_LIST] [smallint] NOT NULL,
 CONSTRAINT [PK_LIST_F] PRIMARY KEY CLUSTERED 
(
	[ID_LIST_F] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NATIONALITE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NATIONALITE](
	[ID_NATIONALITE] [smallint] IDENTITY(1,1) NOT NULL,
	[NOM] [char](32) NOT NULL,
 CONSTRAINT [PK_NATIONALITE] PRIMARY KEY CLUSTERED 
(
	[ID_NATIONALITE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOTE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOTE](
	[ID_NOTE] [smallint] IDENTITY(1,1) NOT NULL,
	[ID_USER] [nvarchar](450) NOT NULL,
	[ID_FILM] [smallint] NOT NULL,
	[NOTE] [tinyint] NOT NULL,
 CONSTRAINT [PK_NOTE] PRIMARY KEY CLUSTERED 
(
	[ID_NOTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REALISATEUR]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REALISATEUR](
	[ID_REALISATEUR] [smallint] IDENTITY(1,1) NOT NULL,
	[NOM] [char](32) NOT NULL,
	[PRENOM] [char](32) NOT NULL,
 CONSTRAINT [PK_REALISATEUR] PRIMARY KEY CLUSTERED 
(
	[ID_REALISATEUR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REALISE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REALISE](
	[ID_REALISATEUR] [smallint] NOT NULL,
	[ID_FILM] [smallint] NOT NULL,
 CONSTRAINT [PK_REALISE] PRIMARY KEY CLUSTERED 
(
	[ID_REALISATEUR] ASC,
	[ID_FILM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaim]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOUS_TITRE]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOUS_TITRE](
	[ID_SOUS_TITRE] [smallint] IDENTITY(1,1) NOT NULL,
	[NOM] [char](32) NOT NULL,
 CONSTRAINT [PK_SOUS_TITRE] PRIMARY KEY CLUSTERED 
(
	[ID_SOUS_TITRE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WISHLIST]    Script Date: 08.06.2020 22:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WISHLIST](
	[ID_WISHLIST] [smallint] IDENTITY(1,1) NOT NULL,
	[ID_FILM] [smallint] NOT NULL,
	[ID_USER] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_WISHLIST] PRIMARY KEY CLUSTERED 
(
	[ID_WISHLIST] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[COMMENTAIRE]  WITH CHECK ADD  CONSTRAINT [FK_COMMENTAIRE_FILM] FOREIGN KEY([ID_FILM])
REFERENCES [dbo].[FILM] ([ID_FILM])
GO
ALTER TABLE [dbo].[COMMENTAIRE] CHECK CONSTRAINT [FK_COMMENTAIRE_FILM]
GO
ALTER TABLE [dbo].[COMMENTAIRE]  WITH CHECK ADD  CONSTRAINT [FK_COMMENTAIRE_UTILISATEUR] FOREIGN KEY([ID_USER])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[COMMENTAIRE] CHECK CONSTRAINT [FK_COMMENTAIRE_UTILISATEUR]
GO
ALTER TABLE [dbo].[FAIT_PARTIE]  WITH CHECK ADD  CONSTRAINT [FK_FAIT_PARTIE_FILM] FOREIGN KEY([ID_FILM])
REFERENCES [dbo].[FILM] ([ID_FILM])
GO
ALTER TABLE [dbo].[FAIT_PARTIE] CHECK CONSTRAINT [FK_FAIT_PARTIE_FILM]
GO
ALTER TABLE [dbo].[FAIT_PARTIE]  WITH CHECK ADD  CONSTRAINT [FK_FAIT_PARTIE_GENRE] FOREIGN KEY([ID_GENRE])
REFERENCES [dbo].[GENRE] ([ID_GENRE])
GO
ALTER TABLE [dbo].[FAIT_PARTIE] CHECK CONSTRAINT [FK_FAIT_PARTIE_GENRE]
GO
ALTER TABLE [dbo].[FILM]  WITH CHECK ADD  CONSTRAINT [FK_FILM_DISTRIBUTEUR] FOREIGN KEY([ID_DISTRIBUTEUR])
REFERENCES [dbo].[DISTRIBUTEUR] ([ID_DISTRIBUTEUR])
GO
ALTER TABLE [dbo].[FILM] CHECK CONSTRAINT [FK_FILM_DISTRIBUTEUR]
GO
ALTER TABLE [dbo].[FILM]  WITH CHECK ADD  CONSTRAINT [FK_FILM_LANGUE] FOREIGN KEY([ID_LANGUE])
REFERENCES [dbo].[LANGUE] ([ID_LANGUE])
GO
ALTER TABLE [dbo].[FILM] CHECK CONSTRAINT [FK_FILM_LANGUE]
GO
ALTER TABLE [dbo].[FILM]  WITH CHECK ADD  CONSTRAINT [FK_FILM_NATIONALITE] FOREIGN KEY([ID_NATIONALITE])
REFERENCES [dbo].[NATIONALITE] ([ID_NATIONALITE])
GO
ALTER TABLE [dbo].[FILM] CHECK CONSTRAINT [FK_FILM_NATIONALITE]
GO
ALTER TABLE [dbo].[FILM]  WITH CHECK ADD  CONSTRAINT [FK_FILM_SOUS_TITRE] FOREIGN KEY([ID_SOUS_TITRE])
REFERENCES [dbo].[SOUS_TITRE] ([ID_SOUS_TITRE])
GO
ALTER TABLE [dbo].[FILM] CHECK CONSTRAINT [FK_FILM_SOUS_TITRE]
GO
ALTER TABLE [dbo].[FILM_POSSEDE]  WITH CHECK ADD  CONSTRAINT [FK_FILM_POSSEDE_FILM] FOREIGN KEY([ID_FILM])
REFERENCES [dbo].[FILM] ([ID_FILM])
GO
ALTER TABLE [dbo].[FILM_POSSEDE] CHECK CONSTRAINT [FK_FILM_POSSEDE_FILM]
GO
ALTER TABLE [dbo].[FILM_POSSEDE]  WITH CHECK ADD  CONSTRAINT [FK_FILM_POSSEDE_UTILISATEUR] FOREIGN KEY([ID_USER])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[FILM_POSSEDE] CHECK CONSTRAINT [FK_FILM_POSSEDE_UTILISATEUR]
GO
ALTER TABLE [dbo].[JOUE]  WITH CHECK ADD  CONSTRAINT [FK_JOUE_ACTEURS] FOREIGN KEY([ID_ACTEUR])
REFERENCES [dbo].[ACTEURS] ([ID_ACTEUR])
GO
ALTER TABLE [dbo].[JOUE] CHECK CONSTRAINT [FK_JOUE_ACTEURS]
GO
ALTER TABLE [dbo].[JOUE]  WITH CHECK ADD  CONSTRAINT [FK_JOUE_FILM] FOREIGN KEY([ID_FILM])
REFERENCES [dbo].[FILM] ([ID_FILM])
GO
ALTER TABLE [dbo].[JOUE] CHECK CONSTRAINT [FK_JOUE_FILM]
GO
ALTER TABLE [dbo].[LIST]  WITH CHECK ADD  CONSTRAINT [FK_LIST_UTILISATEUR] FOREIGN KEY([ID_USER])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[LIST] CHECK CONSTRAINT [FK_LIST_UTILISATEUR]
GO
ALTER TABLE [dbo].[LIST_F]  WITH CHECK ADD  CONSTRAINT [FK_LIST_F_FILM] FOREIGN KEY([ID_FILM])
REFERENCES [dbo].[FILM] ([ID_FILM])
GO
ALTER TABLE [dbo].[LIST_F] CHECK CONSTRAINT [FK_LIST_F_FILM]
GO
ALTER TABLE [dbo].[LIST_F]  WITH CHECK ADD  CONSTRAINT [FK_LIST_F_LIST] FOREIGN KEY([ID_LIST])
REFERENCES [dbo].[LIST] ([ID_LIST])
GO
ALTER TABLE [dbo].[LIST_F] CHECK CONSTRAINT [FK_LIST_F_LIST]
GO
ALTER TABLE [dbo].[NOTE]  WITH CHECK ADD  CONSTRAINT [FK_NOTE_FILM] FOREIGN KEY([ID_FILM])
REFERENCES [dbo].[FILM] ([ID_FILM])
GO
ALTER TABLE [dbo].[NOTE] CHECK CONSTRAINT [FK_NOTE_FILM]
GO
ALTER TABLE [dbo].[NOTE]  WITH CHECK ADD  CONSTRAINT [FK_NOTE_UTILISATEUR] FOREIGN KEY([ID_USER])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[NOTE] CHECK CONSTRAINT [FK_NOTE_UTILISATEUR]
GO
ALTER TABLE [dbo].[REALISE]  WITH CHECK ADD  CONSTRAINT [FK_REALISE_FILM] FOREIGN KEY([ID_FILM])
REFERENCES [dbo].[FILM] ([ID_FILM])
GO
ALTER TABLE [dbo].[REALISE] CHECK CONSTRAINT [FK_REALISE_FILM]
GO
ALTER TABLE [dbo].[REALISE]  WITH CHECK ADD  CONSTRAINT [FK_REALISE_REALISATEUR] FOREIGN KEY([ID_REALISATEUR])
REFERENCES [dbo].[REALISATEUR] ([ID_REALISATEUR])
GO
ALTER TABLE [dbo].[REALISE] CHECK CONSTRAINT [FK_REALISE_REALISATEUR]
GO
ALTER TABLE [dbo].[WISHLIST]  WITH CHECK ADD  CONSTRAINT [FK_WISHLIST_FILM] FOREIGN KEY([ID_FILM])
REFERENCES [dbo].[FILM] ([ID_FILM])
GO
ALTER TABLE [dbo].[WISHLIST] CHECK CONSTRAINT [FK_WISHLIST_FILM]
GO
ALTER TABLE [dbo].[WISHLIST]  WITH CHECK ADD  CONSTRAINT [FK_WISHLIST_UTILISATEUR] FOREIGN KEY([ID_USER])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WISHLIST] CHECK CONSTRAINT [FK_WISHLIST_UTILISATEUR]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'en attente/approuvé' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMMENTAIRE', @level2type=N'COLUMN',@level2name=N'STATUT'
GO
USE [master]
GO
ALTER DATABASE [DBMovieToGo] SET  READ_WRITE 
GO
