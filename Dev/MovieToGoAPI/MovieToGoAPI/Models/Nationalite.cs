using System;
using System.Collections.Generic;

namespace MovieToGoAPI.Models
{
    public partial class Nationalite
    {
        public Nationalite()
        {
            Film = new HashSet<Film>();
        }

        public short IdNationalite { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Film> Film { get; set; }
    }
}
