using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class Droit
    {
        public Droit()
        {
            Utilisateur = new HashSet<Utilisateur>();
        }

        public short IdDoit { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Utilisateur> Utilisateur { get; set; }
    }
}
