﻿using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class Note
    {
        public short IdNote { get; set; }
        public short IdUser { get; set; }
        public short IdFilm { get; set; }
        public byte Note1 { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Utilisateur IdUserNavigation { get; set; }
    }
}
