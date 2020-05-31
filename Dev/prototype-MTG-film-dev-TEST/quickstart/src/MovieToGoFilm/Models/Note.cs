using System;
using System.Collections.Generic;

namespace MovieToGoFilm.Models
{
    public partial class Note
    {
        public short IdNote { get; set; }
        public string Id { get; set; }
        public short IdFilm { get; set; }
        public byte Note1 { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual AspNetUsers IdNavigation { get; set; }
    }
}
