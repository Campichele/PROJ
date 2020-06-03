using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class List
    {
        public List()
        {
            ListF = new HashSet<ListF>();
        }

        public short IdList { get; set; }
        public short IdUser { get; set; }
        public string Nom { get; set; }
        public short FkUser { get; set; }

        public virtual Utilisateur IdUserNavigation { get; set; }
        public virtual ICollection<ListF> ListF { get; set; }
    }
}
