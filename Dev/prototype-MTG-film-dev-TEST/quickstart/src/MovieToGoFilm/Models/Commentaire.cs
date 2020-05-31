using System;
using System.Collections.Generic;

namespace MovieToGoFilm.Models
{
    public partial class Commentaire
    {
        public short IdCommentaire { get; set; }
        public string Id { get; set; }
        public short IdFilm { get; set; }
        public string Commentaire1 { get; set; }
        public bool Statut { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual AspNetUsers IdNavigation { get; set; }
    }
}
