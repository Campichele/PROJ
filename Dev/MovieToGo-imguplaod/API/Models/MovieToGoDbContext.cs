﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class MovieToGoDbContext : DbContext
    {

        public MovieToGoDbContext(DbContextOptions<MovieToGoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acteurs> Acteurs { get; set; }
        public virtual DbSet<Commentaire> Commentaire { get; set; }
        public virtual DbSet<Distributeur> Distributeur { get; set; }
        public virtual DbSet<FaitPartie> FaitPartie { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmPossede> FilmPossede { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Joue> Joue { get; set; }
        public virtual DbSet<Langue> Langue { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<ListF> ListF { get; set; }
        public virtual DbSet<Nationalite> Nationalite { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Realisateur> Realisateur { get; set; }
        public virtual DbSet<Realise> Realise { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SousTitre> SousTitre { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserTokens> UserTokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acteurs>(entity =>
            {
                entity.HasKey(e => e.IdActeur);

                entity.ToTable("ACTEURS");

                entity.Property(e => e.IdActeur).HasColumnName("ID_ACTEUR");

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Prenom)
                    .HasColumnName("PRENOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.HasKey(e => e.IdCommentaire);

                entity.ToTable("COMMENTAIRE");

                entity.Property(e => e.IdCommentaire).HasColumnName("ID_COMMENTAIRE");

                entity.Property(e => e.Commentaire1)
                    .IsRequired()
                    .HasColumnName("COMMENTAIRE")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("ID_USER")
                    .HasMaxLength(450);

                entity.Property(e => e.Statut)
                    .HasColumnName("STATUT")
                    .HasComment("en attente/approuvé");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Commentaire)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMENTAIRE_FILM");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Commentaire)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMENTAIRE_UTILISATEUR");
            });

            modelBuilder.Entity<Distributeur>(entity =>
            {
                entity.HasKey(e => e.IdDistributeur);

                entity.ToTable("DISTRIBUTEUR");

                entity.Property(e => e.IdDistributeur).HasColumnName("ID_DISTRIBUTEUR");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<FaitPartie>(entity =>
            {
                entity.HasKey(e => new { e.IdGenre, e.IdFilm });

                entity.ToTable("FAIT_PARTIE");

                entity.Property(e => e.IdGenre).HasColumnName("ID_GENRE");

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.FaitPartie)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAIT_PARTIE_FILM");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.FaitPartie)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAIT_PARTIE_GENRE");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.IdFilm);

                entity.ToTable("FILM");

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.Property(e => e.DateDeSortie)
                    .HasColumnName("DATE_DE_SORTIE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasColumnType("text");

                entity.Property(e => e.Duree).HasColumnName("DUREE");

                entity.Property(e => e.Fichier)
                    .HasColumnName("FICHIER")
                    .HasColumnType("text");

                entity.Property(e => e.IdDistributeur).HasColumnName("ID_DISTRIBUTEUR");

                entity.Property(e => e.IdLangue).HasColumnName("ID_LANGUE");

                entity.Property(e => e.IdNationalite).HasColumnName("ID_NATIONALITE");

                entity.Property(e => e.IdSousTitre).HasColumnName("ID_SOUS_TITRE");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Prix)
                    .HasColumnName("PRIX")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdDistributeurNavigation)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.IdDistributeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_DISTRIBUTEUR");

                entity.HasOne(d => d.IdLangueNavigation)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.IdLangue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_LANGUE");

                entity.HasOne(d => d.IdNationaliteNavigation)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.IdNationalite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_NATIONALITE");

                entity.HasOne(d => d.IdSousTitreNavigation)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.IdSousTitre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_SOUS_TITRE");
            });

            modelBuilder.Entity<FilmPossede>(entity =>
            {
                entity.HasKey(e => e.IdFilmPossede);

                entity.ToTable("FILM_POSSEDE");

                entity.Property(e => e.IdFilmPossede).HasColumnName("ID_FILM_POSSEDE");

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("ID_USER")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.FilmPossede)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_POSSEDE_FILM");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.FilmPossede)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_POSSEDE_UTILISATEUR");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre);

                entity.ToTable("GENRE");

                entity.Property(e => e.IdGenre).HasColumnName("ID_GENRE");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Joue>(entity =>
            {
                entity.HasKey(e => new { e.IdActeur, e.IdFilm });

                entity.ToTable("JOUE");

                entity.Property(e => e.IdActeur).HasColumnName("ID_ACTEUR");

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.HasOne(d => d.IdActeurNavigation)
                    .WithMany(p => p.Joue)
                    .HasForeignKey(d => d.IdActeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOUE_ACTEURS");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Joue)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOUE_FILM");
            });

            modelBuilder.Entity<Langue>(entity =>
            {
                entity.HasKey(e => e.IdLangue);

                entity.ToTable("LANGUE");

                entity.Property(e => e.IdLangue).HasColumnName("ID_LANGUE");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => e.IdList);

                entity.ToTable("LIST");

                entity.Property(e => e.IdList).HasColumnName("ID_LIST");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("ID_USER")
                    .HasMaxLength(450);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.List)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIST_UTILISATEUR");
            });

            modelBuilder.Entity<ListF>(entity =>
            {
                entity.HasKey(e => e.IdListF);

                entity.ToTable("LIST_F");

                entity.Property(e => e.IdListF).HasColumnName("ID_LIST_F");

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.Property(e => e.IdList).HasColumnName("ID_LIST");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.ListF)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIST_F_FILM");

                entity.HasOne(d => d.IdListNavigation)
                    .WithMany(p => p.ListF)
                    .HasForeignKey(d => d.IdList)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIST_F_LIST");
            });

            modelBuilder.Entity<Nationalite>(entity =>
            {
                entity.HasKey(e => e.IdNationalite);

                entity.ToTable("NATIONALITE");

                entity.Property(e => e.IdNationalite).HasColumnName("ID_NATIONALITE");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.IdNote);

                entity.ToTable("NOTE");

                entity.Property(e => e.IdNote).HasColumnName("ID_NOTE");

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("ID_USER")
                    .HasMaxLength(450);

                entity.Property(e => e.Note1).HasColumnName("NOTE");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTE_FILM");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTE_UTILISATEUR");
            });

            modelBuilder.Entity<Realisateur>(entity =>
            {
                entity.HasKey(e => e.IdRealisateur);

                entity.ToTable("REALISATEUR");

                entity.Property(e => e.IdRealisateur).HasColumnName("ID_REALISATEUR");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("PRENOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Realise>(entity =>
            {
                entity.HasKey(e => new { e.IdRealisateur, e.IdFilm });

                entity.ToTable("REALISE");

                entity.Property(e => e.IdRealisateur).HasColumnName("ID_REALISATEUR");

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Realise)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REALISE_FILM");

                entity.HasOne(d => d.IdRealisateurNavigation)
                    .WithMany(p => p.Realise)
                    .HasForeignKey(d => d.IdRealisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REALISE_REALISATEUR");
            });

            modelBuilder.Entity<SousTitre>(entity =>
            {
                entity.HasKey(e => e.IdSousTitre);

                entity.ToTable("SOUS_TITRE");

                entity.Property(e => e.IdSousTitre).HasColumnName("ID_SOUS_TITRE");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("NOM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<UserTokens>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasKey(e => e.IdWishlist);

                entity.ToTable("WISHLIST");

                entity.Property(e => e.IdWishlist).HasColumnName("ID_WISHLIST");

                entity.Property(e => e.IdFilm).HasColumnName("ID_FILM");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("ID_USER")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WISHLIST_FILM");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WISHLIST_UTILISATEUR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
