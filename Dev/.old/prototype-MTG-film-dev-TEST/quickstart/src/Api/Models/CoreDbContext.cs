using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acteur> Acteurs { get; set; }
        public virtual DbSet<Commentaire> Commentaires { get; set; }
        public virtual DbSet<Distributeur> Distributeurs { get; set; }
        public virtual DbSet<Droit> Droits { get; set; }
        public virtual DbSet<FaitPartie> FaitParties { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmPossede> FilmPossedes { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Joue> Joues { get; set; }
        public virtual DbSet<Langue> Langues { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<ListF> ListFs { get; set; }
        public virtual DbSet<Nationalite> Nationalites { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Realisateur> Realisateurs { get; set; }
        public virtual DbSet<Realise> Realises { get; set; }
        public virtual DbSet<SousTitre> SousTitres { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GO1CBQ7\\SQLEXPRESS;Database=MovieToGo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acteur>(entity =>
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
                    .WithMany(p => p.Commentaires)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMENTAIRE_FILM");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Commentaires)
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
                    .WithMany(p => p.FaitParties)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAIT_PARTIE_FILM");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.FaitParties)
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
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdDistributeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_DISTRIBUTEUR");

                entity.HasOne(d => d.IdLangueNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdLangue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_LANGUE");

                entity.HasOne(d => d.IdNationaliteNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdNationalite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_NATIONALITE");

                entity.HasOne(d => d.IdSousTitreNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdSousTitre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_SOUS_TITRE");
            });

            modelBuilder.Entity<FilmPossede>(entity =>
            {
                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.FilmPossedes)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_POSSEDE_FILM");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.FilmPossedes)
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
                    .WithMany(p => p.Joues)
                    .HasForeignKey(d => d.IdActeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOUE_ACTEURS");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Joues)
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
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIST_UTILISATEUR");
            });

            modelBuilder.Entity<ListF>(entity =>
            {
                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.ListFs)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIST_F_FILM");

                entity.HasOne(d => d.IdListNavigation)
                    .WithMany(p => p.ListFs)
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
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTE_FILM");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Notes)
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
                    .WithMany(p => p.Realises)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REALISE_FILM");

                entity.HasOne(d => d.IdRealisateurNavigation)
                    .WithMany(p => p.Realises)
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
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.IdDoit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UTILISATEUR_DROIT");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WISHLIST_FILM");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WISHLIST_UTILISATEUR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
