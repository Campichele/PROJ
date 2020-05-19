﻿using System;
using System.Collections.Generic;

namespace MovieToGoAPI.Models
{
    public partial class Realise
    {
        public short IdRealisateur { get; set; }
        public short IdFilm { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Realisateur IdRealisateurNavigation { get; set; }
    }
}
