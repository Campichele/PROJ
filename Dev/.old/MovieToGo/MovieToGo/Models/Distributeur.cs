using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class Distributeur
    {
        public Distributeur()
        {
            Film = new HashSet<Film>();
        }

        public short IdDistributeur { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Film> Film { get; set; }
    }
}
