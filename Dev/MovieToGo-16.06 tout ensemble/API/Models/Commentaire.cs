using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Commentaire
    {
        public short IdCommentaire { get; set; }
        public string IdUser { get; set; }
        public short IdFilm { get; set; }
        public string Commentaire1 { get; set; }
        public bool Statut { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
