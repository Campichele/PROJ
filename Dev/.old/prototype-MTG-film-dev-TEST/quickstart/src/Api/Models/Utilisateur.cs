using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("UTILISATEUR")]
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Commentaires = new HashSet<Commentaire>();
            FilmPossedes = new HashSet<FilmPossede>();
            Lists = new HashSet<List>();
            Notes = new HashSet<Note>();
            Wishlists = new HashSet<Wishlist>();
        }

        [Key]
        [Column("ID_USER")]
        public short IdUser { get; set; }
        [Column("ID_DOIT")]
        public short IdDoit { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }
        [Required]
        [Column("PRENOM")]
        [StringLength(32)]
        public string Prenom { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(32)]
        public string Email { get; set; }
        [Required]
        [Column("PASSWORD")]
        [StringLength(255)]
        public string Password { get; set; }
        [Column("STATUT")]
        public bool Statut { get; set; }
        [Required]
        [Column("PSEUDO")]
        [StringLength(32)]
        public string Pseudo { get; set; }

        [ForeignKey(nameof(IdDoit))]
        [InverseProperty(nameof(Droit.Utilisateurs))]
        public virtual Droit IdDoitNavigation { get; set; }
        [InverseProperty(nameof(Commentaire.IdUserNavigation))]
        public virtual ICollection<Commentaire> Commentaires { get; set; }
        [InverseProperty(nameof(FilmPossede.IdUserNavigation))]
        public virtual ICollection<FilmPossede> FilmPossedes { get; set; }
        [InverseProperty(nameof(List.IdUserNavigation))]
        public virtual ICollection<List> Lists { get; set; }
        [InverseProperty(nameof(Note.IdUserNavigation))]
        public virtual ICollection<Note> Notes { get; set; }
        [InverseProperty(nameof(Wishlist.IdUserNavigation))]
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
