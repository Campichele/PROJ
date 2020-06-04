using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class Langue
    {
        public Langue()
        {
            Film = new HashSet<Film>();
        }

        public short IdLangue { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Film> Film { get; set; }
    }
}
