/*
 ----------------------------------------------------------------------------
             Génération d'une base de données pour
                        SQL Server 2005
                       (5/5/2020 9:00:23)
 ----------------------------------------------------------------------------
     Nom de la base : MLR1
     Projet : Accueil Win'Design version 16
     Auteur : ETML
     Date de dernière modification : 5/5/2020 8:58:59
 ----------------------------------------------------------------------------
*/


/* -----------------------------------------------------------------------------
      OUVERTURE DE LA BASE MLR1
----------------------------------------------------------------------------- */

create database MLR1
go

use MLR1
go


CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_ASPNETROLECLAIMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10.05.2020 12:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [varchar](256) NULL,
	[NormalizedName] [varchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10.05.2020 12:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_ASPNETUSERCLAIMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10.05.2020 12:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [varchar](450) NOT NULL,
	[ProviderKey] [varchar](450) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [text] NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10.05.2020 12:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



/* -----------------------------------------------------------------------------
      TABLE : UTILISATEUR
----------------------------------------------------------------------------- */

GO
CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
	[NOM] 					char(32)  not null  ,
    [PRENOM] 					char(32)  not null  ,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
)

/* -----------------------------------------------------------------------------
      TABLE : NATIONALITE
----------------------------------------------------------------------------- */

create table NATIONALITE
  (
     ID_NATIONALITE smallint identity (1, 1)   ,
     NOM char(32)  not null  
     ,
     constraint PK_NATIONALITE primary key (ID_NATIONALITE)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : FILM_POSSEDE
----------------------------------------------------------------------------- */

create table FILM_POSSEDE
  (
     ID_FILM_POSSEDE smallint identity (1, 1)   ,
     ID_FILM smallint  not null  ,
     [Id] NVARCHAR (450) NOT NULL 
     ,
     constraint PK_FILM_POSSEDE primary key (ID_FILM_POSSEDE)
  ) 
go


/* -----------------------------------------------------------------------------
      TABLE : COMMENTAIRE
----------------------------------------------------------------------------- */

create table COMMENTAIRE
  (
     ID_COMMENTAIRE smallint identity (1, 1)   ,
     [Id] NVARCHAR (450) NOT NULL,
     ID_FILM smallint  not null  ,
     COMMENTAIRE char(255)  not null  ,
     STATUT bit  not null  
     ,
     constraint PK_COMMENTAIRE primary key (ID_COMMENTAIRE)
  ) 
go

DECLARE @current_user char(30)
SET @current_user = CURRENT_USER
exec sp_addextendedproperty N'MS_Description', N'en attente/approuvé', N'user', @current_user, N'table', N'COMMENTAIRE',N'column', N'STATUT'
go



/*      INDEX DE COMMENTAIRE      */



/* -----------------------------------------------------------------------------
      TABLE : LIST_F
----------------------------------------------------------------------------- */

create table LIST_F
  (
     ID_LIST_F smallint identity (1, 1)   ,
     ID_FILM smallint  not null  ,
     ID_LIST smallint  not null  
     ,
     constraint PK_LIST_F primary key (ID_LIST_F)
  ) 
go



/*      INDEX DE LIST_F      */



/* -----------------------------------------------------------------------------
      TABLE : LIST
----------------------------------------------------------------------------- */

create table LIST
  (
     ID_LIST smallint identity (1, 1)   ,
     [Id] NVARCHAR (450) NOT NULL,
     NOM char(32)  not null  
     ,
     constraint PK_LIST primary key (ID_LIST)
  ) 
go



/*      INDEX DE LIST      */



/* -----------------------------------------------------------------------------
      TABLE : REALISATEUR
----------------------------------------------------------------------------- */

create table REALISATEUR
  (
     ID_REALISATEUR smallint identity (1, 1)   ,
     NOM char(32)  not null  ,
     PRENOM char(32)  not null,
     constraint PK_REALISATEUR primary key (ID_REALISATEUR)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : WISHLIST
----------------------------------------------------------------------------- */

create table WISHLIST
  (
     ID_WISHLIST smallint identity (1, 1)   ,
     ID_FILM smallint  not null  ,
     [Id] NVARCHAR (450) NOT NULL 
     ,
     constraint PK_WISHLIST primary key (ID_WISHLIST)
  ) 
go



/*      INDEX DE WISHLIST      */



/* -----------------------------------------------------------------------------
      TABLE : ACTEURS
----------------------------------------------------------------------------- */

create table ACTEURS
  (
     ID_ACTEUR smallint identity (1, 1)   ,
     NOM char(32)  null  ,
     PRENOM char(32)  null  
     ,
     constraint PK_ACTEURS primary key (ID_ACTEUR)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : GENRE
----------------------------------------------------------------------------- */

create table GENRE
  (
     ID_GENRE smallint identity (1, 1)   ,
     NOM char(32)  not null  
     ,
     constraint PK_GENRE primary key (ID_GENRE)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : NOTE
----------------------------------------------------------------------------- */

create table NOTE
  (
     ID_NOTE smallint identity (1, 1)   ,
     [Id] NVARCHAR (450) NOT NULL ,
     ID_FILM smallint  not null  ,
     NOTE tinyint  not null  
     ,
     constraint PK_NOTE primary key (ID_NOTE)
  ) 
go



/*      INDEX DE NOTE      */



/* -----------------------------------------------------------------------------
      TABLE : FILM
----------------------------------------------------------------------------- */

create table FILM
  (
     ID_FILM smallint identity (1, 1)   ,
     ID_DISTRIBUTEUR smallint  not null  ,
     ID_SOUS_TITRE smallint  not null  ,
     ID_LANGUE smallint  not null  ,
     ID_NATIONALITE smallint  not null  ,
     NOM char(32)  not null  ,
     DATE_DE_SORTIE datetime  not null  ,
     DESCRIPTION text  null  ,
     DUREE smallint  not null  ,
     PRIX decimal(10,2)  not null  ,
     FICHIER text  null  
     ,
     constraint PK_FILM primary key (ID_FILM)
  ) 
go



/*      INDEX DE FILM      */



/* -----------------------------------------------------------------------------
      TABLE : DISTRIBUTEUR
----------------------------------------------------------------------------- */

create table DISTRIBUTEUR
  (
     ID_DISTRIBUTEUR smallint identity (1, 1)   ,
     NOM char(32)  not null  
     ,
     constraint PK_DISTRIBUTEUR primary key (ID_DISTRIBUTEUR)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : SOUS_TITRE
----------------------------------------------------------------------------- */

create table SOUS_TITRE
  (
     ID_SOUS_TITRE smallint identity (1, 1)   ,
     NOM char(32)  not null  
     ,
     constraint PK_SOUS_TITRE primary key (ID_SOUS_TITRE)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : LANGUE
----------------------------------------------------------------------------- */

create table LANGUE
  (
     ID_LANGUE smallint identity (1, 1)   ,
     NOM char(32)  not null  
     ,
     constraint PK_LANGUE primary key (ID_LANGUE)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : REALISE
----------------------------------------------------------------------------- */

create table REALISE
  (
     ID_REALISATEUR smallint  not null  ,
     ID_FILM smallint  not null  
     ,
     constraint PK_REALISE primary key (ID_REALISATEUR, ID_FILM)
  ) 
go



/*      INDEX DE REALISE      */



/* -----------------------------------------------------------------------------
      TABLE : JOUE
----------------------------------------------------------------------------- */

create table JOUE
  (
     ID_ACTEUR smallint  not null  ,
     ID_FILM smallint  not null  
     ,
     constraint PK_JOUE primary key (ID_ACTEUR, ID_FILM)
  ) 
go



/*      INDEX DE JOUE      */



/* -----------------------------------------------------------------------------
      TABLE : FAIT_PARTIE
----------------------------------------------------------------------------- */

create table FAIT_PARTIE
  (
     ID_GENRE smallint  not null  ,
     ID_FILM smallint  not null  
     ,
     constraint PK_FAIT_PARTIE primary key (ID_GENRE, ID_FILM)
  ) 
go



/*      INDEX DE FAIT_PARTIE      */



/* -----------------------------------------------------------------------------
      REFERENCES SUR LES TABLES
----------------------------------------------------------------------------- */



alter table FILM_POSSEDE 
     add constraint FK_FILM_POSSEDE_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go




alter table FILM_POSSEDE 
     add constraint FK_FILM_POSSEDE_UTILISATEUR foreign key ([Id]) 
               references [dbo].[AspNetUsers] ([Id])
go




alter table COMMENTAIRE 
     add constraint FK_COMMENTAIRE_UTILISATEUR foreign key ([Id]) 
               references [dbo].[AspNetUsers] ([Id])
go




alter table COMMENTAIRE 
     add constraint FK_COMMENTAIRE_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go


alter table LIST_F 
     add constraint FK_LIST_F_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go




alter table LIST_F 
     add constraint FK_LIST_F_LIST foreign key (ID_LIST) 
               references LIST (ID_LIST)
go




alter table LIST 
     add constraint FK_LIST_UTILISATEUR foreign key ([Id]) 
               references [dbo].[AspNetUsers] ([Id])
go




alter table WISHLIST 
     add constraint FK_WISHLIST_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go




alter table WISHLIST 
     add constraint FK_WISHLIST_UTILISATEUR foreign key ([Id]) 
               references [dbo].[AspNetUsers] ([Id])
go




alter table NOTE 
     add constraint FK_NOTE_UTILISATEUR foreign key ([Id]) 
               references [dbo].[AspNetUsers] ([Id])
go




alter table NOTE 
     add constraint FK_NOTE_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go




alter table FILM 
     add constraint FK_FILM_DISTRIBUTEUR foreign key (ID_DISTRIBUTEUR) 
               references DISTRIBUTEUR (ID_DISTRIBUTEUR)
go




alter table FILM 
     add constraint FK_FILM_SOUS_TITRE foreign key (ID_SOUS_TITRE) 
               references SOUS_TITRE (ID_SOUS_TITRE)
go




alter table FILM 
     add constraint FK_FILM_LANGUE foreign key (ID_LANGUE) 
               references LANGUE (ID_LANGUE)
go




alter table FILM 
     add constraint FK_FILM_NATIONALITE foreign key (ID_NATIONALITE) 
               references NATIONALITE (ID_NATIONALITE)
go




alter table REALISE 
     add constraint FK_REALISE_REALISATEUR foreign key (ID_REALISATEUR) 
               references REALISATEUR (ID_REALISATEUR)
go




alter table REALISE 
     add constraint FK_REALISE_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go




alter table JOUE 
     add constraint FK_JOUE_ACTEURS foreign key (ID_ACTEUR) 
               references ACTEURS (ID_ACTEUR)
go




alter table JOUE 
     add constraint FK_JOUE_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go




alter table FAIT_PARTIE 
     add constraint FK_FAIT_PARTIE_GENRE foreign key (ID_GENRE) 
               references GENRE (ID_GENRE)
go




alter table FAIT_PARTIE 
     add constraint FK_FAIT_PARTIE_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go

/*
ALTER TABLE [dbo].[AspNetUserClaims] WITH CHECK ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO
*/
ALTER TABLE [dbo].[AspNetUserClaims] WITH CHECK ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserLogins] WITH CHECK ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] WITH CHECK ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] WITH CHECK ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

/*DATAS*/
--users
INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [NOM], [PRENOM]) VALUES (1,0,NULL,NULL,0,0,NULL,NULL,NULL,NULL,NULL,0,NULL,0,'pat','Ducoin','Patrick')
GO

--DISTRIBUTEUR
SET IDENTITY_INSERT DISTRIBUTEUR  ON 
INSERT DISTRIBUTEUR ([ID_DISTRIBUTEUR],[NOM]) VALUES (1,'Gaumont')
SET IDENTITY_INSERT DISTRIBUTEUR OFF
GO


--LANGUE
SET IDENTITY_INSERT LANGUE  ON 
INSERT LANGUE ([ID_LANGUE], [NOM]) VALUES (1,'Francais')
SET IDENTITY_INSERT LANGUE OFF
GO

--NATIONALITE
SET IDENTITY_INSERT NATIONALITE  ON 
INSERT NATIONALITE ([ID_NATIONALITE], [NOM]) VALUES (1,'Francais')
SET IDENTITY_INSERT NATIONALITE OFF
GO

--SOUS_TITRE
SET IDENTITY_INSERT SOUS_TITRE  ON 
INSERT SOUS_TITRE ([ID_SOUS_TITRE], [NOM]) VALUES (1,'ENG')
SET IDENTITY_INSERT SOUS_TITRE OFF
GO

--FILM
SET IDENTITY_INSERT FILM  ON 
INSERT FILM ([ID_FILM], [ID_DISTRIBUTEUR],[ID_SOUS_TITRE],[ID_LANGUE],[ID_NATIONALITE],[NOM],[DATE_DE_SORTIE],[DESCRIPTION],[DUREE],[PRIX],[FICHIER]) VALUES (1,1,1,1,1,'Avengers',2012-01-01,'test',123,12.00,'test')
SET IDENTITY_INSERT FILM OFF
GO


--Commentaires
SET IDENTITY_INSERT COMMENTAIRE  ON 
INSERT COMMENTAIRE (ID_COMMENTAIRE, [Id], ID_FILM, COMMENTAIRE, STATUT) VALUES (1,1,1,'Je suis satisfait',0)
INSERT COMMENTAIRE (ID_COMMENTAIRE, [Id], ID_FILM, COMMENTAIRE, STATUT) VALUES (2,1,1,'2eme comm',0)
INSERT COMMENTAIRE (ID_COMMENTAIRE, [Id], ID_FILM, COMMENTAIRE, STATUT) VALUES (3,1,1,'fonctionne2?',0)
INSERT COMMENTAIRE (ID_COMMENTAIRE, [Id], ID_FILM, COMMENTAIRE, STATUT) VALUES (4,1,1,'Je suis satisfait',0)
INSERT COMMENTAIRE (ID_COMMENTAIRE, [Id], ID_FILM, COMMENTAIRE, STATUT) VALUES (5,1,1,'newnewn',0)
SET IDENTITY_INSERT COMMENTAIRE OFF
GO


/*
 -----------------------------------------------------------------------------
               FIN DE GENERATION
 -----------------------------------------------------------------------------
*/