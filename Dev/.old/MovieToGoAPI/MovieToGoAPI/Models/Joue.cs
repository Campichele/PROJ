using System;
using System.Collections.Generic;

namespace MovieToGoAPI.Models
{
    public partial class Joue
    {
        public short IdActeur { get; set; }
        public short IdFilm { get; set; }

        public virtual Acteurs IdActeurNavigation { get; set; }
        public virtual Film IdFilmNavigation { get; set; }
    }
}
