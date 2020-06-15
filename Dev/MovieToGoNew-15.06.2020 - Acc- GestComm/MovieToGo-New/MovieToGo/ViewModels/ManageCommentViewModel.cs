using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieToGo.ViewModels
{
    public class ManageCommentViewModel
    {
        public short IdCommentaire { get; set; }
        public short IdUser { get; set; }
        public short IdFilm { get; set; }
        public string Commentaire1 { get; set; }
        public bool Statut { get; set; }
    }
}
