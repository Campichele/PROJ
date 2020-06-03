using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class MovieToGoDbContext : DbContext
    {
        public MovieToGoDbContext()
        {
        }

        public MovieToGoDbContext(DbContextOptions<MovieToGoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acteurs> Acteurs { get; set; }
        public virtual DbSet<Commentaire> Commentaire { get; set; }
        public virtual DbSet<Distributeur> Distributeur { get; set; }
        public virtual DbSet<Droit> Droit { get; set; }
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
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GO1CBQ7\\SQLEXPRESS;Database=MTGDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acteurs>(entity =>
            {
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Prenom)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.Property(e => e.Commentaire1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Statut).HasComment("en attente/approuvé");

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
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Droit>(entity =>
            {
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<FaitPartie>(entity =>
            {
                entity.HasKey(e => new { e.IdGenre, e.IdFilm });

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
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Joue>(entity =>
            {
                entity.HasKey(e => new { e.IdActeur, e.IdFilm });

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
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.Property(e => e.Nom)
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
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Note>(entity =>
            {
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
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Prenom)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Realise>(entity =>
            {
                entity.HasKey(e => new { e.IdRealisateur, e.IdFilm });

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
                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nom)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pseudo)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Statut).HasComment("actif/non actif (ban)");

                entity.HasOne(d => d.IdDoitNavigation)
                    .WithMany(p => p.Utilisateur)
                    .HasForeignKey(d => d.IdDoit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UTILISATEUR_DROIT");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
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
