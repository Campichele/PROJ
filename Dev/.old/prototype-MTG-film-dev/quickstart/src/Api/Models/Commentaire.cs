using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("COMMENTAIRE")]
    public partial class Commentaire
    {
        [Key]
        [Column("ID_COMMENTAIRE")]
        public short IdCommentaire { get; set; }
        [Column("ID_USER")]
        public short IdUser { get; set; }
        [Column("ID_FILM")]
        public short IdFilm { get; set; }
        [Required]
        [Column("COMMENTAIRE")]
        [StringLength(255)]
        public string Commentaire1 { get; set; }
        [Column("STATUT")]
        public bool Statut { get; set; }

        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.Commentaires))]
        public virtual Film IdFilmNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Utilisateur.Commentaires))]
        public virtual Utilisateur IdUserNavigation { get; set; }
    }
}
