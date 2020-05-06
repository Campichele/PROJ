using System;
using System.Collections.Generic;

namespace MovieToGoFilm.Models
{
    public partial class Genre
    {
        public Genre()
        {
            FaitPartie = new HashSet<FaitPartie>();
        }

        public short IdGenre { get; set; }
        public string Nom { get; set; }
        public string SearchString { get; set; }

        public virtual ICollection<FaitPartie> FaitPartie { get; set; }
    }
}
