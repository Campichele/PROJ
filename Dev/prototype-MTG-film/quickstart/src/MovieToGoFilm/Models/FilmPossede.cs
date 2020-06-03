using System;
using System.Collections.Generic;

namespace MovieToGoFilm.Models
{
    public partial class FilmPossede
    {
        public short IdFilmPossede { get; set; }
        public short IdFilm { get; set; }
        public short IdUser { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Utilisateur IdUserNavigation { get; set; }
    }
}
