using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("FILM")]
    public partial class Film
    {
        public Film()
        {
            Commentaires = new HashSet<Commentaire>();
            FaitParties = new HashSet<FaitPartie>();
            FilmPossedes = new HashSet<FilmPossede>();
            Joues = new HashSet<Joue>();
            ListFs = new HashSet<ListF>();
            Notes = new HashSet<Note>();
            Realises = new HashSet<Realise>();
            Wishlists = new HashSet<Wishlist>();
        }

        [Key]
        [Column("ID_FILM")]
        public short IdFilm { get; set; }
        [Column("ID_DISTRIBUTEUR")]
        public short IdDistributeur { get; set; }
        [Column("ID_SOUS_TITRE")]
        public short IdSousTitre { get; set; }
        [Column("ID_LANGUE")]
        public short IdLangue { get; set; }
        [Column("ID_NATIONALITE")]
        public short IdNationalite { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }
        [Column("DATE_DE_SORTIE", TypeName = "date")]
        public DateTime DateDeSortie { get; set; }
        [Column("DESCRIPTION", TypeName = "text")]
        public string Description { get; set; }
        [Column("DUREE")]
        public short Duree { get; set; }
        [Column("PRIX", TypeName = "decimal(18, 2)")]
        public decimal? Prix { get; set; }
        [Column("FICHIER", TypeName = "text")]
        public string Fichier { get; set; }

        [ForeignKey(nameof(IdDistributeur))]
        [InverseProperty(nameof(Distributeur.Films))]
        public virtual Distributeur IdDistributeurNavigation { get; set; }
        [ForeignKey(nameof(IdLangue))]
        [InverseProperty(nameof(Langue.Films))]
        public virtual Langue IdLangueNavigation { get; set; }
        [ForeignKey(nameof(IdNationalite))]
        [InverseProperty(nameof(Nationalite.Films))]
        public virtual Nationalite IdNationaliteNavigation { get; set; }
        [ForeignKey(nameof(IdSousTitre))]
        [InverseProperty(nameof(SousTitre.Films))]
        public virtual SousTitre IdSousTitreNavigation { get; set; }
        [InverseProperty(nameof(Commentaire.IdFilmNavigation))]
        public virtual ICollection<Commentaire> Commentaires { get; set; }
        [InverseProperty(nameof(FaitPartie.IdFilmNavigation))]
        public virtual ICollection<FaitPartie> FaitParties { get; set; }
        [InverseProperty(nameof(FilmPossede.IdFilmNavigation))]
        public virtual ICollection<FilmPossede> FilmPossedes { get; set; }
        [InverseProperty(nameof(Joue.IdFilmNavigation))]
        public virtual ICollection<Joue> Joues { get; set; }
        [InverseProperty(nameof(ListF.IdFilmNavigation))]
        public virtual ICollection<ListF> ListFs { get; set; }
        [InverseProperty(nameof(Note.IdFilmNavigation))]
        public virtual ICollection<Note> Notes { get; set; }
        [InverseProperty(nameof(Realise.IdFilmNavigation))]
        public virtual ICollection<Realise> Realises { get; set; }
        [InverseProperty(nameof(Wishlist.IdFilmNavigation))]
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
