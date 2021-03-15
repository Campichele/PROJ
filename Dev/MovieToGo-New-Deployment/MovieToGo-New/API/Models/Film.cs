using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("FILM")]
    public partial class Film
    {
        public Film()
        {
            Commentaire = new HashSet<Commentaire>();
            FaitPartie = new HashSet<FaitPartie>();
            FilmPossede = new HashSet<FilmPossede>();
            Joue = new HashSet<Joue>();
            ListF = new HashSet<ListF>();
            Note = new HashSet<Note>();
            Realise = new HashSet<Realise>();
            Wishlist = new HashSet<Wishlist>();
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
        [Column("DATE_DE_SORTIE", TypeName = "datetime")]
        public DateTime DateDeSortie { get; set; }
        [Column("DESCRIPTION", TypeName = "text")]
        public string Description { get; set; }
        [Column("DUREE")]
        public short Duree { get; set; }
        [Column("PRIX", TypeName = "decimal(10, 2)")]
        public decimal Prix { get; set; }
        [Column("FICHIER", TypeName = "text")]
        public string Fichier { get; set; }

        [ForeignKey(nameof(IdDistributeur))]
        [InverseProperty(nameof(Distributeur.Film))]
        public virtual Distributeur IdDistributeurNavigation { get; set; }
        [ForeignKey(nameof(IdLangue))]
        [InverseProperty(nameof(Langue.Film))]
        public virtual Langue IdLangueNavigation { get; set; }
        [ForeignKey(nameof(IdNationalite))]
        [InverseProperty(nameof(Nationalite.Film))]
        public virtual Nationalite IdNationaliteNavigation { get; set; }
        [ForeignKey(nameof(IdSousTitre))]
        [InverseProperty(nameof(SousTitre.Film))]
        public virtual SousTitre IdSousTitreNavigation { get; set; }
        [InverseProperty("IdFilmNavigation")]
        public virtual ICollection<Commentaire> Commentaire { get; set; }
        [InverseProperty("IdFilmNavigation")]
        public virtual ICollection<FaitPartie> FaitPartie { get; set; }
        [InverseProperty("IdFilmNavigation")]
        public virtual ICollection<FilmPossede> FilmPossede { get; set; }
        [InverseProperty("IdFilmNavigation")]
        public virtual ICollection<Joue> Joue { get; set; }
        [InverseProperty("IdFilmNavigation")]
        public virtual ICollection<ListF> ListF { get; set; }
        [InverseProperty("IdFilmNavigation")]
        public virtual ICollection<Note> Note { get; set; }
        [InverseProperty("IdFilmNavigation")]
        public virtual ICollection<Realise> Realise { get; set; }
        [InverseProperty("IdFilmNavigation")]
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
