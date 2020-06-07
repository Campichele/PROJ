using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("FAIT_PARTIE")]
    public partial class FaitPartie
    {
        [Key]
        [Column("ID_GENRE")]
        public short IdGenre { get; set; }
        [Key]
        [Column("ID_FILM")]
        public short IdFilm { get; set; }

        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.FaitPartie))]
        public virtual Film IdFilmNavigation { get; set; }
        [ForeignKey(nameof(IdGenre))]
        [InverseProperty(nameof(Genre.FaitPartie))]
        public virtual Genre IdGenreNavigation { get; set; }
    }
}
