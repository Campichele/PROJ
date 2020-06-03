using System;
using System.Collections.Generic;

namespace MovieToGoAPI.Models
{
    public partial class SousTitre
    {
        public SousTitre()
        {
            Film = new HashSet<Film>();
        }

        public short IdSousTitre { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Film> Film { get; set; }
    }
}
