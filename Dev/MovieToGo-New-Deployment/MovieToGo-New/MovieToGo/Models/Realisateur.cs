using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class Realisateur
    {
        public Realisateur()
        {
            Realise = new HashSet<Realise>();
        }

        public short IdRealisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public virtual ICollection<Realise> Realise { get; set; }
    }
}
