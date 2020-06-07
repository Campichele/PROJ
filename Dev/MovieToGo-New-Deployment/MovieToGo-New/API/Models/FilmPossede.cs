using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("FILM_POSSEDE")]
    public partial class FilmPossede
    {
        [Key]
        [Column("ID_FILM_POSSEDE")]
        public short IdFilmPossede { get; set; }
        [Column("ID_FILM")]
        public short IdFilm { get; set; }
        [Column("ID_USER")]
        public short IdUser { get; set; }

        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.FilmPossede))]
        public virtual Film IdFilmNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Utilisateur.FilmPossede))]
        public virtual Utilisateur IdUserNavigation { get; set; }
    }
}
