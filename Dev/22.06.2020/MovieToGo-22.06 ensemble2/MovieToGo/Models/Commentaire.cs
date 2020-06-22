using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieToGo.Models
{
    public partial class Commentaire
    {
        public short IdCommentaire { get; set; }
        public string IdUser { get; set; }
        public short IdFilm { get; set; }

        [Display(Name = "Commentaire")]
        public string Commentaire1 { get; set; }
        public bool Statut { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
