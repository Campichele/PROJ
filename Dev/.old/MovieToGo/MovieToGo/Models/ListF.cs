using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class ListF
    {
        public short IdFilm { get; set; }
        public short IdList { get; set; }
        public short FkFilm { get; set; }
        public short FkList { get; set; }
        public short IdListF { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual List IdListNavigation { get; set; }
    }
}
