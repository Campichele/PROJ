using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class ListF
    {
        public short IdListF { get; set; }
        public short IdFilm { get; set; }
        public short IdList { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual List IdListNavigation { get; set; }
    }
}
