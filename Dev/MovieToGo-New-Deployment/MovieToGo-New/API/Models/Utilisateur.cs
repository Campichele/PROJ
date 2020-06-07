using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("UTILISATEUR")]
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Commentaire = new HashSet<Commentaire>();
            FilmPossede = new HashSet<FilmPossede>();
            List = new HashSet<List>();
            Note = new HashSet<Note>();
            Wishlist = new HashSet<Wishlist>();
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
        [InverseProperty(nameof(Droit.Utilisateur))]
        public virtual Droit IdDoitNavigation { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Commentaire> Commentaire { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<FilmPossede> FilmPossede { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<List> List { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Note> Note { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
