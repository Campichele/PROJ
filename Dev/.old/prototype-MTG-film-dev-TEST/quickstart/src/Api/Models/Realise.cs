using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("REALISE")]
    public partial class Realise
    {
        [Key]
        [Column("ID_REALISATEUR")]
        public short IdRealisateur { get; set; }
        [Key]
        [Column("ID_FILM")]
        public short IdFilm { get; set; }

        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.Realises))]
        public virtual Film IdFilmNavigation { get; set; }
        [ForeignKey(nameof(IdRealisateur))]
        [InverseProperty(nameof(Realisateur.Realises))]
        public virtual Realisateur IdRealisateurNavigation { get; set; }
    }
}
