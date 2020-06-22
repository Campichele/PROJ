using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Acteurs
    {
        public Acteurs()
        {
            Joue = new HashSet<Joue>();
        }

        public short IdActeur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public virtual ICollection<Joue> Joue { get; set; }
    }
}
