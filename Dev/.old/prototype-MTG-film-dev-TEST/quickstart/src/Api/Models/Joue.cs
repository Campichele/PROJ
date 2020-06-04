using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("JOUE")]
    public partial class Joue
    {
        [Key]
        [Column("ID_ACTEUR")]
        public short IdActeur { get; set; }
        [Key]
        [Column("ID_FILM")]
        public short IdFilm { get; set; }

        [ForeignKey(nameof(IdActeur))]
        [InverseProperty(nameof(Acteur.Joues))]
        public virtual Acteur IdActeurNavigation { get; set; }
        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.Joues))]
        public virtual Film IdFilmNavigation { get; set; }
    }
}
