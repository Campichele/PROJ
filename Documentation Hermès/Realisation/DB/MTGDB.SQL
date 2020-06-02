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

drop database MTGDB
go

/* -----------------------------------------------------------------------------
      OUVERTURE DE LA BASE MLR1
----------------------------------------------------------------------------- */

create database MTGDB
go

use MTGDB
go



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
     ID_USER smallint  not null  
     ,
     constraint PK_FILM_POSSEDE primary key (ID_FILM_POSSEDE)
  ) 
go



/*      INDEX DE FILM_POSSEDE      */



/* -----------------------------------------------------------------------------
      TABLE : COMMENTAIRE
----------------------------------------------------------------------------- */

create table COMMENTAIRE
  (
     ID_COMMENTAIRE smallint identity (1, 1)   ,
     ID_USER smallint  not null  ,
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
      TABLE : DROIT
----------------------------------------------------------------------------- */

create table DROIT
  (
     ID_DOIT smallint identity (1, 1)   ,
     NOM char(32)  not null  
     ,
     constraint PK_DROIT primary key (ID_DOIT)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : UTILISATEUR
----------------------------------------------------------------------------- */

create table UTILISATEUR
  (
     ID_USER smallint identity (1, 1)   ,
     ID_DOIT smallint  not null  ,
     NOM char(32)  not null  ,
     PRENOM char(32)  not null  ,
     EMAIL char(32)  not null  ,
     PASSWORD varchar(255)  not null  ,
     STATUT bit  not null  ,
     PSEUDO char(32)  not null  
     ,
     constraint PK_UTILISATEUR primary key (ID_USER)
  ) 
go

DECLARE @current_user char(30)
SET @current_user = CURRENT_USER
exec sp_addextendedproperty N'MS_Description', N'actif/non actif (ban)', N'user', @current_user, N'table', N'UTILISATEUR',N'column', N'STATUT'
go



/*      INDEX DE UTILISATEUR      */



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
     ID_USER smallint  not null  ,
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
     PRENOM char(32)  not null  
     ,
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
     ID_USER smallint  not null  
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
     ID_USER smallint  not null  ,
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
     add constraint FK_FILM_POSSEDE_UTILISATEUR foreign key (ID_USER) 
               references UTILISATEUR (ID_USER)
go




alter table COMMENTAIRE 
     add constraint FK_COMMENTAIRE_UTILISATEUR foreign key (ID_USER) 
               references UTILISATEUR (ID_USER)
go




alter table COMMENTAIRE 
     add constraint FK_COMMENTAIRE_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go




alter table UTILISATEUR 
     add constraint FK_UTILISATEUR_DROIT foreign key (ID_DOIT) 
               references DROIT (ID_DOIT)
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
     add constraint FK_LIST_UTILISATEUR foreign key (ID_USER) 
               references UTILISATEUR (ID_USER)
go




alter table WISHLIST 
     add constraint FK_WISHLIST_FILM foreign key (ID_FILM) 
               references FILM (ID_FILM)
go




alter table WISHLIST 
     add constraint FK_WISHLIST_UTILISATEUR foreign key (ID_USER) 
               references UTILISATEUR (ID_USER)
go




alter table NOTE 
     add constraint FK_NOTE_UTILISATEUR foreign key (ID_USER) 
               references UTILISATEUR (ID_USER)
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
 -----------------------------------------------------------------------------
               FIN DE GENERATION
 -----------------------------------------------------------------------------
*/