using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Note
    {
        public short IdNote { get; set; }
        public string IdUser { get; set; }
        public short IdFilm { get; set; }
        public byte Note1 { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
