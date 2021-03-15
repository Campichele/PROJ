using System;
using System.Collections.Generic;

namespace MovieToGoAPI.Models
{
    public partial class FaitPartie
    {
        public short IdGenre { get; set; }
        public short IdFilm { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
    }
}
