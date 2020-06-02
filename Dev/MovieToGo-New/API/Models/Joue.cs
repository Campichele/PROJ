using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
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
        [InverseProperty(nameof(Acteurs.Joue))]
        public virtual Acteurs IdActeurNavigation { get; set; }
        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.Joue))]
        public virtual Film IdFilmNavigation { get; set; }
    }
}
