using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class FilmPossede
    {
        public short IdFilmPossede { get; set; }
        public short IdFilm { get; set; }
        public string IdUser { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
