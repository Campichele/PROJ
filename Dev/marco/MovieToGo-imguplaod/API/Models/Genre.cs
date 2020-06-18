﻿using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Genre
    {
        public Genre()
        {
            FaitPartie = new HashSet<FaitPartie>();
        }

        public short IdGenre { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<FaitPartie> FaitPartie { get; set; }
    }
}
